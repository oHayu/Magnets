using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ships : MovingObject {
    public int health = 1;
    public GameObject explosion;

    public void Damage() {
        health--;
        if (health <= 0) {
            Die();
        }
    }

    protected override void Die() {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
