using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UCE Skills/UCE Projectile Skill1", order = 999)]
public abstract partial class ProjectileTargetless : UCE_ProjectileSkill
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
  
