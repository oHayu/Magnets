using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBull : Enemy {
    Vector3 charge;
    private bool hasLocation;

    void Update() {

        Vector2 offset = transform.position - target.position;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));

        if (hasLocation) {
            transform.position = Vector3.MoveTowards(transform.position, charge, thrust);

        }
    }

    private Vector3 getChargePosition() {
        return target.position;
    }
    protected override void Action() {
        SoundManager.instance.playPew(5);
        charge = getChargePosition();
        hasLocation = true;
    }
    
}
