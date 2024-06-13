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

    private GameManager gameManager;

    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", spawnTime, repeatSpawn);

        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        if(playerControllerScript.gameover == false &&  gameManager.gameStart == true)
        {
            Instantiate(obstaclePrejabs, spawnPos, obstaclePrejabs.transform.rotation);
        }
    }
}
