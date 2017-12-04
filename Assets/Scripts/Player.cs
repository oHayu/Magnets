using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ships {
    public GameObject glue;
    public static Player instance;
    public int availableBombs = 2;


    void Awake() {
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
        Vector2 movement = new Vector2(x, y);

        rb.AddForce(movement);

        Vector2 pivotPoint = new Vector2(Camera.main.WorldToScreenPoint(transform.position).x, Camera.main.WorldToScreenPoint(transform.position).y);
        Vector2 offset = new Vector2(Input.mousePosition.x - pivotPoint.x, Input.mousePosition.y - pivotPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        float leftright = x * -Input.mousePosition.y + y * Input.mousePosition.x;
        Quaternion toRot = Quaternion.Euler(new Vector3(0f, RotationY(movement, Input.mousePosition), angle - 270));
        transform.localRotation = Quaternion.RotateTowards(transform.rotation, toRot, thrust * Time.deltaTime);


    }

    public void ChangeBombAmount(int change) {
        availableBombs += change;
    }

    IEnumerator killGluedOn() {
        foreach (Transform enemyGlued in glue.GetComponentInChildren<Transform>()) {
            Instantiate(explosion, enemyGlued.position, Quaternion.identity);
            enemyGlued.gameObject.SetActive(false);
            SoundManager.instance.PlayBoom(1);
            yield return new WaitForSeconds(0.1f);
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    protected override void Die() {
        SoundManager.instance.PlayBoom(1);
        GameController.instance.PlayerDied();
        StartCoroutine("killGluedOn");

    }
}
