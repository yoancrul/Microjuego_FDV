using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorito : MonoBehaviour
{
    public float maxTimeLife = 4f;
    public float speed = 10f;
    public Vector2 gravedad = Vector2.down;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Destruir(maxTimeLife));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(gravedad * speed * Time.deltaTime);
    }
    private IEnumerator Destruir(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
