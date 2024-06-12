using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrejabs;

    private float spawnTime = 2;

    private float repeatSpawn = 2;

    private UnityEngine.Vector3 spawnPos = new UnityEngine.Vector3 (30, 0, 0);

    private Playercontroller playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", spawnTime, repeatSpawn);

        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameover == false)
        {
        }
    }

    void SpawnObstacles()
    {
        if(playerControllerScript.gameover == false)
        {
            Instantiate(obstaclePrejabs, spawnPos, obstaclePrejabs.transform.rotation);
        }
    }
}
