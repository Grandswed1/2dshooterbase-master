using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnModule : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab; 

    float spawntimer = 0;

    [SerializeField]
    float timeBetweenEnemies = 1.5f;

    // Update is called once per frame
    void Update()
    {
        spawntimer += Time.deltaTime;

        if (spawntimer > timeBetweenEnemies)
        {
            Instantiate(enemyPrefab);
            spawntimer = 0;
        }
    }
}
