using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 7.0f;

    private Playercontroller playerControllerScript;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameover == false && gameManager.isGameStart)
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(transform.position.x < -10 && gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
    }
}
