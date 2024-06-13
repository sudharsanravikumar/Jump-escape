using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private Playercontroller playerControllerScript;
    private Animator playerAnimator;
    public bool isGameStart;
    public bool objectcollision;
    public bool exit;
    public int score = 0;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public Button restartButton;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        button=button.GetComponent<Button>();
        button.onClick.AddListener(StartGame);
        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameover)
        {
            GameOver();
        }
    }

    void StartGame()
    {
        Debug.Log(button.gameObject.name +" is Clicked");
        isGameStart= true;
        titleScreen.gameObject.SetActive(false);
        playerAnimator.enabled = true;
        playerControllerScript.enabled = true;
    }

    private void OnTriggerEnter(Collider other) 
    {
            objectcollision = true;
            Debug.Log(other.gameObject + " is objectCollider Name");
            Debug.Log(objectcollision + " is object collider");
            score++;
            scoreText.text = "Score: " + score;
        
    }

     void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif

    }

}