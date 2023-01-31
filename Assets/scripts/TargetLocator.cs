using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectile;
    Transform Target;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        EnemyBehaviour[] enemies = FindObjectsOfType<EnemyBehaviour>();
        Transform closestTarget = null;
        float MaxDistance = Mathf.Infinity;

        foreach(EnemyBehaviour enemy in enemies)
        {
            float targetdistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetdistance<MaxDistance)
            {
                closestTarget = enemy.transform;
                MaxDistance = targetdistance;
            }
        }
        Target = closestTarget;
    }
        

    void AimWeapon()
    {
        float targetdistance = Vector3.Distance(transform.position, Target.position);
        weapon.LookAt(Target);
        if(targetdistance<range)
        {
            BowEmission(true);
        }
        else
        {
            BowEmission(false);
        }
                
    }

    void BowEmission(bool isActive)
    {
        var emissionmodule = projectile.emission;
        emissionmodule.enabled = isActive;
    }

    
}
