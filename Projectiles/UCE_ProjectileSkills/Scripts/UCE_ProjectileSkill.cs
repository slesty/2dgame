// =======================================================================================
// Created and maintained by Fhiz
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// =======================================================================================

using UnityEngine;

// =======================================================================================
// UCE PROJECTILE SKILL
// =======================================================================================
[CreateAssetMenu(menuName = "UCE Skills/UCE Projectile Skill", order = 999)]
public partial class UCE_ProjectileSkill : UCE_DamageSkill
{
    public override bool CheckTarget(Entity caster)
    {
        caster.target = caster;
        return true;
    }
    public override bool CheckDistance(Entity caster, int skillLevel, out Vector2 destination)
    {
        destination = caster.transform.position;
        return true;
    }
}



// =======================================================================================