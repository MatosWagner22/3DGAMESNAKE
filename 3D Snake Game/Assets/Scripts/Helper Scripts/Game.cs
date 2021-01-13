using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;
    public GameObject fruitPickup, bombPickup;

    private float minX = -4.25f, maxX = 4.25f, minY = -2.26f, maxY = 2.26f;
    private float zpos = 5.8f;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        Invoke("StartSpawning", 0.5f);
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

}
