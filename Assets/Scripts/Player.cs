using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ships {
    public GameObject glue;
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



        Vector2 pivotPoint = new Vector2(Camera.main.WorldToScreenPoint(transform.position).x, Camera.main.WorldToScreenPoint(transform.position).y);
        Vector2 offset = new Vector2(Input.mousePosition.x - pivotPoint.x, Input.mousePosition.y - pivotPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 270));

    }
}
