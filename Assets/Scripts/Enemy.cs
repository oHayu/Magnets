using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ships {
    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = transform.position - target.position;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle-90));



        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > 1f) {//move if distance from target is greater than 1
            transform.position = Vector3.MoveTowards(transform.position, target.position, thrust);
        }
    }
}
