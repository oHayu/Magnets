using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Ships {
    public int score = 10;
    public Transform target;
    public bool hasAction;
    public float actionRate = 4f;

    void Start() {
        if (hasAction) {
            InvokeRepeating("Action", actionRate, actionRate);
        }   
    }
    protected abstract void Action();

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            transform.SetParent(Player.instance.glue.transform);
            collision.gameObject.GetComponent<Rigidbody2D>().mass += 0.2f;
            this.enabled = false;
            this.tag = "Player";
            gameObject.layer = LayerMask.NameToLayer("Player");
            Destroy(rb);
        }
    }

    protected override void Die() {
        SoundManager.instance.PlayBoom(1);
        base.Die();
        GameController.instance.UpdateScore(this.score);
    }
}
