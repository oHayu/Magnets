using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : EnemyTracker {

    public GameObject killSelf;

    protected override void Action() {
        EnemyPool.instance.killAllEnemies();
        Instantiate(killSelf, transform.position, Quaternion.identity);
        this.Die();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Player.instance.Damage();
            Action();
        }
    }
}
