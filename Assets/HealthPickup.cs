using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField]
    GameObject healthPrefab; 

    GameObject bigCapsule;

    float spawntimer = 0;

    [SerializeField]
    float timeBetweenHealth = 5.0f;

    // Update is called once per frame
    void Update()
    {
        spawntimer += Time.deltaTime;

        if (spawntimer > timeBetweenHealth)
        {
            Instantiate(healthPrefab);
            spawntimer = 0;
        }
    }
    
    void Start () 
    {
        bigCapsule = GameObject.Find ("Ship");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" )
        {
            Destroy(this.gameObject);
            bigCapsule.GetComponent < ShipController > ().currentHp += 5;
            bigCapsule.GetComponent < ShipController > ().updateHealthSlider ();
        }
    }
}
