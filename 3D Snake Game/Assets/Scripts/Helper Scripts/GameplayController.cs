using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    public GameObject fruit_PickUp, bomb_PickUp;

    private float min_x = -4.25f, max_x = 4.25f, min_y = -2.26f, max_y = 2.26f;
    private float z_Pos = 5.8f;

    private Text score_Text;
    private int scoreCount;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        score_Text = GameObject.Find("Score").GetComponent<Text>();

        Invoke("StartSpawning", 0.5f);
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void StartSpawning()
    {
        StarCoroutine(SpawnPickUps());
    }

    IEnumerator SpawnPickUps()
    {
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));

        if (Random.Range(0, 10) >= 2)
        {
            Instantiate(fruit_PickUp, new Vector3(Random.Range(min_x, max_x), Random.Range(min_y, max_y), z_Pos), Quarternion.identity);
        }
        else
        {
            Instantiate(bomb_PickUp, new Vector3(Random.Range(min_x, max_x), Random.Range(min_y, max_y), z_Pos), Quarternion.identity);
        }

        Invoke("StartSpawning", 0f);
    }

    public void IncreaseScore()
    {
        scoreCount++;
        score_Text.text = "Score: " + scoreCount;
    }

} // class
