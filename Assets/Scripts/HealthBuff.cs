using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public int amount;
    
    public override void Apply(GameObject target)
    {
        if (target.GetComponent<HealthController>().playerHealth < target.GetComponent<HealthController>().maxHealth)
        {
            target.GetComponent<HealthController>().playerHealth += amount;
            target.GetComponent<HealthController>().UpdateHealth();
        }
    }
}
