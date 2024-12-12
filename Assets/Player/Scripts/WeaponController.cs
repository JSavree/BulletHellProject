using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject beam, chargeBeam;
    public GameObject chargeFX;
    public int currentWeapon = 1;
    int barrel_index = 0;

    public float shotSpeed;

    [SerializeField] bool isCharging;
    [SerializeField] float chargeTime;
    [SerializeField] float timeToCharge;
    [SerializeField] UIManagement _UIManager;
    private float shotCooldown;

    void Update()
    {
        if (currentWeapon == 2)
        {
            if (Input.GetMouseButton(0))
            {
                isCharging = true;
                chargeTime += Time.deltaTime;

                if (isCharging == true && chargeTime > 0.1f)
                {
                    chargeFX.SetActive(true);
                }
            }

            if (Input.GetMouseButtonUp(0) && (chargeTime >= timeToCharge))
            {
                ChargeShoot();
                chargeFX.SetActive(false);
            }
            else if (Input.GetMouseButtonUp(0) && (chargeTime < timeToCharge))
            {
                chargeTime = 0;
                chargeFX.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            currentWeapon = (currentWeapon % 2) + 1;
            _UIManager.updateWeapon(currentWeapon);
        }
        
    }

    void ChargeShoot()
    {
        GameObject chargeShot = Instantiate(chargeBeam, firePoint.position, firePoint.rotation);
        Rigidbody2D chargeRB = chargeShot.GetComponent<Rigidbody2D>();
        chargeRB.AddForce(firePoint.up * shotSpeed, ForceMode2D.Impulse);
        Destroy(chargeShot.gameObject, 1f);
        
        isCharging = false;
        chargeTime = 0;
    }
}
