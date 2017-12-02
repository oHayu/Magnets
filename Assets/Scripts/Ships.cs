using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ships : MovingObject {
    public int health = 1;

    public void Damage() {
        health--;
        if (health <= 0) {
            Die();
        }
    }
}
