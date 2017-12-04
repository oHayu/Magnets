using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public List<Transform> spawnPoints;
    public List<Enemy> enemyTypes;
    public float spawnRate;
    private float timeSinceLastSpawn = 0;

	// Update is called once per frame
	void Update () {
        if (timeSinceLastSpawn >= spawnRate) {
            spawnEnemies();
            timeSinceLastSpawn = 0;
        }
        timeSinceLastSpawn += Time.deltaTime;
    }


    public void spawnEnemies() {
        Transform location = spawnPoints[Random.Range(0, 3)];
        int amount = Random.Range(1, 4);


        for (int i = 0; i < amount; i++) {
            Instantiate(enemyTypes[Random.Range(0, enemyTypes.Count)], location.position, Quaternion.identity);
        }
    }
}
