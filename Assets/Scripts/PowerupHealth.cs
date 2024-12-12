using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHealth : MonoBehaviour
{
    public PowerupEffect powerupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            powerupEffect.Apply(collision.gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
