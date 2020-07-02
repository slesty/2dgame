// =======================================================================================
// Created and maintained by Fhiz
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// =======================================================================================
using Mirror;
using UnityEngine;

// =======================================================================================
// UCE ARROW PROJECTILE
// =======================================================================================
[RequireComponent(typeof(NetworkIdentity))]
public class UCE_ArrowProjectile : UCE_Projectile
{
    // -----------------------------------------------------------------------------------
    // Start
    // -----------------------------------------------------------------------------------
    
    [Header("Configuracion")] public LinearFloat distance;

    [Header("Components")] public Animator animator;

    [HideInInspector] public Vector3 startPosition;
    [HideInInspector] public Vector3 direction;
    [HideInInspector] public bool start = false;

    // -----------------------------------------------------------------------------------
    // Start
    // -----------------------------------------------------------------------------------

    public override void OnStartClient()
    {
        if (caster == null) return;
        transform.position = caster.effectMount.position;
        startPosition = caster.transform.position;
        direction = caster.lookDirection;
        start = true;
        onSetInitialPosition.Invoke();
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        Entity candidate = co.GetComponentInParent<Entity>();
        if (candidate != null && caster.CanAttack(candidate))
        {
            caster.target = candidate;
            OnProjectileImpact(candidate);
        }
    }
    // -----------------------------------------------------------------------------------
    // FixedUpdate
    // -----------------------------------------------------------------------------------
    public override void FixedUpdate()
    {
        if (!start) return;
        //checkWall();
        if (Vector3.Distance(transform.position, startPosition) > distance.Get(data.skillLevel))
        {
           NetworkServer.Destroy(gameObject);
           return;
       }
       transform.Translate(direction * (speed * Time.fixedDeltaTime), Space.World);
    }

    [ClientCallback]
    public override void Update()
    {
        // base.Update();
        if (animator == null) return;
        Vector2 direction = transform.position - startPosition;
        animator.SetFloat("DirectionX", direction.x);
        animator.SetFloat("DirectionY", direction.y);
    }
}

// =======================================================================================