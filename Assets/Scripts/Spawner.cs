using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public static Spawner instance; 
    public List<Transform> spawnPoints;
    public List<Enemy> enemyTypes;
    public bool canSpawn; 
    public float spawnRate;
    private float timeSinceLastSpawn = 0;
    public GameObject enemySpawned;


    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void canSpawnChange() {
        canSpawn = !canSpawn;
    }
    void Update() {
        if (timeSinceLastSpawn >= spawnRate && canSpawn) {
            StartCoroutine("spawnEnemies");

            timeSinceLastSpawn = 0;
        }
        timeSinceLastSpawn += Time.deltaTime;
    }


    IEnumerator spawnEnemies() {
        int amount = Random.Range(1, 4);

        for (int i = 0; i < amount; i++) {

            Transform location = spawnPoints[Random.Range(0, 3)];

            Enemy temp = Instantiate(enemyTypes[Random.Range(0, enemyTypes.Count)], location.position + new Vector3(Random.Range(0, 3), Random.Range(0, 3), 0.5f), Quaternion.identity);
            temp.transform.SetParent(enemySpawned.transform);
            yield return new WaitForSeconds(1f);
        }
    }
}
