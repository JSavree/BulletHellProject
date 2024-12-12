using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using BulletHell;


public class BossFight : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float secsToWait;
    public HealthBar healthBar;
    [SerializeField] private GameObject[] bulletHellPatterns;
    
    private int currPattern;
    private GameObject currBulletSpawner;

    
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        for (int i = 1; i < bulletHellPatterns.Length; i++)
        {
            bulletHellPatterns[i].GetComponent<ProjectileEmitterAdvanced>().enabled = false; //.SetActive(false);
        }
    }

    public void DamageBoss(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile") {
            DamageBoss(5);
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        BossPhase();
    }

    private void DestroyBoss()
    {
        Destroy(this.gameObject);
    }

    private void PhasesLogic(int phase)
    {
        if (phase == 1)
        {
            secsToWait -= Time.deltaTime;  

            if(secsToWait<=0) {
                secsToWait = Random.Range(10.0f, 15.0f);
                // do thing here:
                bulletHellPatterns[currPattern].GetComponent<ProjectileEmitterAdvanced>().enabled = false;
                currPattern = Random.Range(0, bulletHellPatterns.Length);
                bulletHellPatterns[currPattern].GetComponent<ProjectileEmitterAdvanced>().enabled = true;
                
            }
        }

        if (phase == 2)
        {
            
        }
    }

    private void DeactivatePhases()
    {
        for (int i = 0; i < bulletHellPatterns.Length; i++)
        {
            bulletHellPatterns[i].GetComponent<ProjectileEmitterAdvanced>().enabled = false; //.SetActive(false);
        }
    }

    
    private void BossPhase()
    {
        if (currentHealth > 60)
        {
            PhasesLogic(1);
        }
        
        if (currentHealth <= 60)
        {
            DeactivatePhases();
            PhasesLogic(2);
        }

        if (currentHealth <= 25)
        {
            DeactivatePhases();
            PhasesLogic(3);
        }

        if (currentHealth < 1)
        {
            DeactivatePhases();
            DestroyBoss();
        }
    }
}
