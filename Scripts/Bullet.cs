using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject BulletPrefab;
    public GameObject BulletExplosionPrefab;

    //timeout the bullet
    void Update() {
        Destroy(BulletPrefab, 5);
    }

    //what to do after collide with something?
    void OnCollisionEnter2D(Collision2D collision) {
        GameObject BulletExplosion = Instantiate(BulletExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(BulletPrefab);
        Destroy(BulletExplosion, 1);
    }
}
