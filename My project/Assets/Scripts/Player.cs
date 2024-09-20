using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody _rigid;
    public float thrustForce = 200f;
    public float rotationSpeed = 150f;
    public GameObject gun, bulletPrefab;
    public static float xBorderLimit, yBorderLimit;



    public static int SCORE;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Texto");
        go.GetComponent<Text>().text = "Puntos: " + Player.SCORE;
        _rigid = GetComponent<Rigidbody>();
        yBorderLimit = Camera.main.orthographicSize + 1;
        xBorderLimit = (Camera.main.orthographicSize + 1) * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = transform.position;
        if (newPos.x > xBorderLimit)
            newPos.x = -xBorderLimit + 1;
        else if (newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit - 1;
        else if (newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit + 1;
        else if (newPos.y < -yBorderLimit)
            newPos.y = yBorderLimit - 1;
        transform.position = newPos;

        float thrust = Input.GetAxis("Vertical") * Time.deltaTime;
        float rotate = Input.GetAxis("Horizontal") * Time.deltaTime;


        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);
        transform.Rotate(Vector3.forward, rotate * rotationSpeed * -1);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = gun.transform.position;
                bullet.SetActive(true);
            }
            bullet balaScript = bullet.GetComponent<bullet>();
            balaScript.targetVector = transform.right * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyS")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SCORE = 0;
        }
    }
}

