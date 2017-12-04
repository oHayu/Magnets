using System.Collections;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

    public static EnemyPool instance;

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    public void killAllEnemies() {
        foreach (Transform enemyActive in GetComponentInChildren<Transform>()) {
            for (int i = 0; i < enemyActive.GetComponent<Enemy>().health; i++) {
                enemyActive.GetComponent<Enemy>().Damage();
            }
        }
    }


}
