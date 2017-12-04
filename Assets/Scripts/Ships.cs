using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ships : MovingObject {
    public int health = 1;
    public GameObject explosion;

    public float RotationY(Vector2 movement, Vector2 reference) {
        float leftright = movement.x * -reference.y + movement.y * reference.x;
        return Mathf.Clamp(leftright * 10, -30, 30);
    }


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
