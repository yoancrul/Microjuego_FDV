using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{
    public float speed = 1000f;
    public float lifeTime = 3f;
    public Vector3 targetVector;
    private GameObject tmp;
    public GameObject meteorSPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destruir(lifeTime));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Enemy")
        {
            IncreaseScore();
            Vector3 meteorPosition = trigger.gameObject.transform.position;
            spawnMeteorS(meteorPosition);
            trigger.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }else if(trigger.gameObject.tag == "EnemyS"){
            IncreaseScore();
            Vector3 meteorPosition = trigger.gameObject.transform.position;
            Destroy(trigger.gameObject);
            gameObject.SetActive(false);
        }
    }

    private void IncreaseScore()
    {
        Player.SCORE += 1;
        Debug.Log(Player.SCORE);
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Texto");
        go.GetComponent<Text>().text = "Puntos: " + Player.SCORE;

    }
    private IEnumerator Destruir(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameObject.SetActive(false);
    }
    private void spawnMeteorS(Vector3 position)
    {
        Vector3 meteor1 = new Vector3(position.x - 1, position.y, position.z);
        Vector3 meteor2 = new Vector3(position.x + 1, position.y, position.z);
        GameObject firstMeteorS = Instantiate(meteorSPrefab, meteor1, Quaternion.identity);
        GameObject secondMeteorS = Instantiate(meteorSPrefab,meteor2, Quaternion.identity);
        Destroy(firstMeteorS, lifeTime);
        Destroy(secondMeteorS, lifeTime);

    }
}
