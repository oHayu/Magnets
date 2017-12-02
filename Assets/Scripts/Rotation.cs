
using UnityEngine;

public class Rotation : MonoBehaviour {


    void Update() {

        Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 pivotPoint = new Vector2(Camera.main.WorldToScreenPoint(transform.position).x, Camera.main.WorldToScreenPoint(transform.position).y);
        Vector2 offset = new Vector2(mouse.x - pivotPoint.x, mouse.y - pivotPoint.y);
        offset.Normalize();
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}