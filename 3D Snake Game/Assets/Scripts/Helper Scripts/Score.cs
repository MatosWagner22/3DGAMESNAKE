using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    private Text score_Text;
    private int scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        score_Text = GameObject.Find("Score").GetComponent<Text>();
    }

    void Awake()
    {
        MakeInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncreaseScore()
    {
        scoreCount++;
        score_Text.text = "Score: " + scoreCount;
    }
}
