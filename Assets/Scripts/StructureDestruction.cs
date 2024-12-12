using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureDestruction : MonoBehaviour
{
    public GameObject hit_effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Structure"))
        {
            Destroy(collision.gameObject);
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
