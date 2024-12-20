﻿using UnityEngine;
using System.Collections;

public class PlayerControlledTurret : MonoBehaviour {

	public GameObject weapon_prefab;
	public GameObject[] barrel_hardpoints;
	public float turret_rotation_speed = 3f;
	public float shot_speed;
	private float shotCooldown;
	public float fireRate;
	int barrel_index = 0;

	[SerializeField] private WeaponController _weaponController;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		//This makes the turret aim at the mouse position (Controlled by CustomPointer, but you can replace CustomPointer.pointerPosition with Input.MousePosition and it should work)
		Vector3 turretPosition = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 direction = Input.mousePosition - turretPosition;
		transform.rotation = Quaternion.Euler (new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2 (direction.y,direction.x) * Mathf.Rad2Deg) - 90f, turret_rotation_speed * Time.deltaTime)));

		if (shotCooldown > 0)
		{
			shotCooldown -= Time.deltaTime;
		}
		
		if (Input.GetMouseButtonDown(0) && barrel_hardpoints != null && (_weaponController.currentWeapon == 1)) {
			if (shotCooldown <= 0)
			{
				shotCooldown = fireRate;
				
				GameObject bullet = (GameObject) Instantiate(weapon_prefab, barrel_hardpoints[barrel_index].transform.position, transform.rotation);
				bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * shot_speed);
				bullet.GetComponent<Projectile>().firing_ship = transform.parent.gameObject;
				barrel_index++; //This will cycle sequentially through the barrels in the barrel_hardpoints array
			
				if (barrel_index >= barrel_hardpoints.Length)
					barrel_index = 0;
			}
		}
	
	}
}
