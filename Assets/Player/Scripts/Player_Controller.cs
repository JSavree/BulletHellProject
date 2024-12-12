using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[SelectionBase]
public class Player_Controller : MonoBehaviour
{
    #region Editor Data
    [Header("Movement Attributes")]
    [SerializeField] float _moveSpeed = 50f;
    
    [Header("Dependencies")] 
    [SerializeField] Rigidbody2D _rb;

    [SerializeField] float player_rotation_speed = 3.0f;
    [SerializeField] private SpriteRenderer _forceFieldRenderer;
    #endregion
    
    #region Internal Data
    private Vector2 _moveDir = Vector2.zero;
    #endregion
    
    #region Tick
    // Update is called once per frame
    void Update()
    {
        GatherInput();
        Vector3 turretPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = Input.mousePosition - turretPosition;
        transform.rotation = Quaternion.Euler (new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2 (direction.y,direction.x) * Mathf.Rad2Deg) - 90f, player_rotation_speed * Time.deltaTime)));
    }

    private void FixedUpdate()
    {
        MovementUpdate();
    }

    #endregion
    
    #region Input Logic
    private void GatherInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");

        //print(_moveDir);
    }
    #endregion
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    #region Movement Logic

    private void MovementUpdate()
    {
        _rb.velocity = _moveDir.normalized * _moveSpeed * Time.fixedDeltaTime;
    }
    #endregion
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BulletHellProjectile")
        {
            print("damage");
        }
        
    }
    
}
