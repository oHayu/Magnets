using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public List<Transform> spawnPoints;
    public List<Enemy> enemyTypes;
    public float spawnRate;
    private float timeSinceLastSpawn = 0;

    // Update is called once per frame
    void Update() {
        if (timeSinceLastSpawn >= spawnRate) {
            StartCoroutine("spawnEnemies");

            timeSinceLastSpawn = 0;
        }
        timeSinceLastSpawn += Time.deltaTime;
    }


    IEnumerator spawnEnemies() {
        int amount = Random.Range(1, 4);

        for (int i = 0; i < amount; i++) {

            Transform location = spawnPoints[Random.Range(0, 3)];

            Instantiate(enemyTypes[Random.Range(0, enemyTypes.Count)], location.position + new Vector3(Random.Range(0, 3), Random.Range(0, 3), 0.5f), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
