using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private Playercontroller playerControllerScript;
    public bool gameStart;
    public bool exit;
    public int score = 0;
    public GameObject titleScreen;
    public GameObject gameOverScreen;

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button=button.GetComponent<Button>();
        button.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    {
        Debug.Log(button.gameObject.name +" is Clicked");
        gameStart = true;
        titleScreen.gameObject.SetActive(false);
    
    }

}