using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public bool isPuased = false;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
     private Vector3 scaleTo = new Vector3(1.4f, 1.4f, 1);
     [SerializeField] float duration = .2f;
    [HideInInspector] public int score;


    [Header("Health")]
    public int heart;
    public int numOfHearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Image[] hearts;


    [Header("Canvas")]
    public bool isDead;
    [SerializeField] GameObject puaseCanvas;
    [SerializeField] GameObject deathCanvas;
    [SerializeField] TextMeshProUGUI highScoreText;


    [Header("Coins")]
    [SerializeField] TextMeshProUGUI coinsText;
     public int coins;

    private void Awake()
    {
        instance = this;
    }
   
   
    void Update()
    {
        scoreText.text = score.ToString(); //set the score

        MakeTheHearts();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Puase();
        }
        
    }
    void MakeTheHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < heart) hearts[i].sprite = fullHeart;
            else hearts[i].sprite = emptyHeart;


            if (i < numOfHearts) hearts[i].enabled = true;
            else hearts[i].enabled = false;
        }
    }
    public void HitRight()
    {
        score++;

        scoreText.rectTransform.DOPunchScale(scaleTo, duration);

        AudioManager.instance.PlaySound("hitRight");
    }
    public void HitWrong()
    {
        if (score != 0)
        {
            score--;
        }

        if (heart != 1) AudioManager.instance.PlaySound("hitWrong");
        else if (heart == 1) AudioManager.instance.PlaySound("hitWrong2");

        heart--;

        StartCoroutine(Shaker.instance.Shake(.1f, .2f));


        if (heart == 0) if(isDead == false)  Die();

    }

    public void Die()
    {
        isDead = true;
        deathCanvas.SetActive(true);
        MakehighScore();
        makeCoinsUI();
        Destroy(GameObject.FindGameObjectWithTag("Coin"));
    }

    void MakehighScore()
    {
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }

        highScoreText.text = "THE HIGH SCORE: " + PlayerPrefs.GetInt("highScore");
    }

    void makeCoinsUI()
    {
        coinsText.text = "x" + PlayerPrefs.GetInt("Coins");
    }

    public void StartGame()
    {
        deathCanvas.SetActive(false);
        isDead = false;
        heart = 3;
        score = 0;
    }

    public void Puase()
    {
        if (isPuased == false)
        {
            isPuased = true;
            puaseCanvas.SetActive(true);
            Time.timeScale = 0.0001f;
        }
        else
        {
            isPuased = false;
            puaseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }

    
}
