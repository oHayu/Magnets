using UnityEngine;

public class EnemyTracker : Enemy {

    protected override void Action() {
        return;
    }

    void Update() {
        if (target != null) {

            Vector2 offset = transform.position - target.position;
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

            transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));
            transform.position = Vector3.MoveTowards(transform.position, target.position, thrust);
        }
    }



}
