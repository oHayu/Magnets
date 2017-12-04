using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {
    public static EnemyPool instance;

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
    }


    public void killAllEnemies() {
        StartCoroutine("killEnemies");
    }

   
}
