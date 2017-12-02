using UnityEngine;

public class MovingObject : MonoBehaviour {
    public Rigidbody2D rb;
    public float thrust = 500f; 
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }


    protected virtual void Die() {
        Destroy(gameObject);
    }
}