using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xLimit;
    private GameObject meteor;
    private float spawnNext = 0f;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-xLimit, xLimit);

            Vector2 spawnPosition = new Vector2(rand, 8f);
            GameObject meteor = ObjectPoolMeteor.SharedInstance.GetPooledObject();
            if (meteor != null)
            {
                meteor.transform.position = spawnPosition;
                meteor.SetActive(true);
            }
        }
    }

}
