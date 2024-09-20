using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    private bool isPaused = false;
    public Text textoPausa;
    private Text pausa;
    private Vector2 position = new Vector2(Screen.width / 2, Screen.height / 2);
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
                pausa = Instantiate(textoPausa, position, Quaternion.identity) as Text;
                pausa.transform.SetParent(canvas.transform);
            }
            else
            {
                Time.timeScale = 1;
                isPaused = false;
                Destroy(pausa);
            }

        }
    }
}
