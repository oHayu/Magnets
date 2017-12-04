using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;
    public GameObject BombBoom; 
    public Transform BulletTrailPrefab;

    float timeToSpawnEffect = 0;
    float timeToFire = 0;
    public float effectSpawnRate = 10;
    Transform firePoint;

    void Start() {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null) {
            Debug.LogError("No firepoint? wat?");
        }
    }

    void Update() {
        if (fireRate == 0) {
            if (Input.GetButtonDown("Fire1")) {
                ShootWeapon();
            }
        }
        else {
            if (Input.GetButton("Fire1") && Time.time > timeToFire) {
                timeToFire = Time.time + 1 / fireRate;
                ShootWeapon();
            }


        }

        if (Input.GetButtonDown("Fire2") && Player.instance.availableBombs > 0) {
            Player.instance.UseBomb();
            ShootBomb();
        }

    }

    void ShootBomb() {
        EnemyPool.instance.killAllEnemies();
        Instantiate(BombBoom, transform.position, Quaternion.identity);
    }

    void ShootWeapon() {
        SoundManager.instance.playPew(0);
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        if(Time.time > timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }

        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);

        if (hit.collider != null) {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            hit.transform.gameObject.GetComponent<Enemy>().Damage();
        }

    }
    void Effect() {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);

    }
}
