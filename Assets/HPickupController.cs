using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-10f, 10f);
        Vector2 pos = new Vector2(x, Camera.main.orthographicSize +1);

        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = -1; // rutor per sekund

        Vector2 movement = new Vector2(0, speed) * Time.deltaTime;
        transform.Translate(movement);

        if (transform.position.y < -Camera.main.orthographicSize -1)
        {
            Destroy(this.gameObject);
        }
    }

}