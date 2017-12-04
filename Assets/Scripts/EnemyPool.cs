using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {
    public static EnemyPool instance;
    public GameObject explosion;

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    IEnumerator killEnemies() {
        foreach (Transform enemyActive in GetComponentInChildren<Transform>()) {
            enemyActive.gameObject.GetComponent<Enemy>().Damage();
            yield return new WaitForSeconds(0.05f);
        }

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    public void killAllEnemies() {
        StartCoroutine("killEnemies");
    }

   
}
