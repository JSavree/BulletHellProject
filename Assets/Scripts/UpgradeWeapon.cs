using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeWeapon : PowerupEffect
{
    
    
    public override void Apply(GameObject target)
    {
        GameObject childTurret = target.transform.Find("Turret Small 2").gameObject;
        
        childTurret.SetActive(true);
    }
}
