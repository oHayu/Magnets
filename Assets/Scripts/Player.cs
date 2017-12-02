using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ships {
    public GameObject explosion;
    public static Player instance;

    void Awake() {
        health = 3;
        rb = GetComponent<Rigidbody2D>();

        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(0, 0);
        float x = Input.GetAxis("Horizontal") * thrust;
        float y = Input.GetAxis("Vertical") * thrust;
        rb.AddForce(new Vector2(x, y));
    }


    protected override void Die() {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }


}