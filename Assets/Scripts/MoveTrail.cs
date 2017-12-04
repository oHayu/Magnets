using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {
    public int moveSpeed = 100;

	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 0.5f);
	}
}
