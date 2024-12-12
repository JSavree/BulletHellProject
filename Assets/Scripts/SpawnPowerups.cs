using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerups : MonoBehaviour
{
    public GameObject powerup;

    public Transform[] spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, spawnPositions.Length);
        Instantiate(powerup, spawnPositions[i].position, spawnPositions[i].rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
