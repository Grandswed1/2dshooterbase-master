using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    [SerializeField]
    int maxHp = 100;

    public int currentHp;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform gunPosition;

    [SerializeField]
    Slider healthSlider;

    [SerializeField]
    TMP_Text healthText;

    float ShotTimer = 0;
    float timeBetweenShots = 0.4f;

    void Awake() {
        currentHp = maxHp;
        updateHealthSlider();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized * speed * Time.deltaTime;
        transform.Translate(movement);

        //Skjutkod

        ShotTimer += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0 && ShotTimer > timeBetweenShots)
        {
            Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            ShotTimer = 0;
        }
    
    }

        private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemy"){
            currentHp -= 10;
            updateHealthSlider();
            if (currentHp <= 0){
            SceneManager.LoadScene(1);
            }
        }

        if(other.gameObject.tag == "HPickup" && currentHp < 100)
        {
            currentHp += 5;
            updateHealthSlider();
        }
    }

    public void updateHealthSlider(){
            healthSlider.maxValue = maxHp;
            healthSlider.value = currentHp;
            healthText.text = currentHp + "/" + maxHp;
    }

}

