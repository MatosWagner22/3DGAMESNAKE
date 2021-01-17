using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game instance;
    public GameObject fruitPickup, bombPickup;

    private float minX = -4.25f, maxX = 4.25f, minY = -2.26f, maxY = 2.26f;
    private float zpos = 5.8f;

    private Text score_Text;
    private int scoreCount;
    public GameObject pausePanel, gameOverPanel;
    public bool pause;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        score_Text = GameObject.Find("Score").GetComponent<Text>();
        scoreCount = 0;
        Invoke("StartSpawning", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            KeepPlay();
        }
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    IEnumerator SpawnPickups()
    {
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));

        if (Random.Range(0, 10) >= 2)
        {
            Instantiate(fruitPickup, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), zpos), Quaternion.identity);
        }
        else
        {
            Instantiate(bombPickup, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), zpos), Quaternion.identity);
        }

        Invoke("StartSpawning", 0f);
    }

    void StartSpawning()
    {
        StartCoroutine(SpawnPickups());
    }

    public void CancelSpawning()
    {
        CancelInvoke("StartSpawning");
    }

    public void IncreaseScore()
    {
        scoreCount++;
        score_Text.text = "Score: " + scoreCount;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if (scoreCount > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", scoreCount);
        }
        else
        {

        }
    }

    public void PlayAgain()
    {
        TimeFixer();
        SceneManager.LoadScene("Main");
    }

    public void TimeFixer()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void Home()
    {
        TimeFixer();
        SceneManager.LoadScene("StartMenu");
    }

    public void Pausar()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void KeepPlay()
    {
        Pausar();
        pause = !pause;
        pausePanel.SetActive(pause);
    }

}
