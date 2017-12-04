using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ships {
    public Transform target;
    public int score = 10; 

    void Update() {
        Vector2 offset = transform.position - target.position;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));

        if (Vector3.Distance(transform.position, target.position) > 1f) {//move if distance from target is greater than 1
            transform.position = Vector3.MoveTowards(transform.position, target.position, thrust);
        }
    }

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
        base.Die();
        //GameController.instance.UpdateScore(this.score);
    }
}
