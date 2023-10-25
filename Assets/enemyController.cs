using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-5f, 5f);
        Vector2 pos = new Vector2(x, Camera.main.orthographicSize +1);

        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = -2; // rutor per sekund

        Vector2 movement = new Vector2(0, speed) * Time.deltaTime;
        transform.Translate(movement);

        if (transform.position.y < -Camera.main.orthographicSize -1)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "bolt" || other.gameObject.tag == "Player" ){
            Destroy(this.gameObject);
            GameObject explosionObject = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(explosionObject, 0.8f);
        }
    }

}