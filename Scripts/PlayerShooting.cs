using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public Transform FirePoint;
    public GameObject BulletPrefab;
    public float BulletForce = 25f;
    public float ReloadTime = 1f;
    float TimePassed = 0f;

    void Update() {
        //time passed
        TimePassed += Time.deltaTime;
        Debug.Log("Time passed since last fire is " + TimePassed + " seconds");
        //if time passed is greater than reload time and input is given, shoot
        if(TimePassed > ReloadTime && Input.GetButton("Fire1")) {
            Shoot();
            //reset timer
            TimePassed = 0;
        }
    }

    void Shoot() {
        //spawn the bullet and reference it
        GameObject Bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        //reference the rigidbody of the bullet
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        //move the bullet
        rb.AddForce(FirePoint.up * BulletForce, ForceMode2D.Impulse);
    }
}
