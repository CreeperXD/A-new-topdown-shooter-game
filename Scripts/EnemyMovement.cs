using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float MoveSpeed = 2.5f;
    public Rigidbody2D enemy;
    public Rigidbody2D Player;
    public Camera camera;
    Vector2 MoveDirection;

    //movements
    void FixedUpdate() {
        //get a direction vector by subtracting enemy position from player position
        Vector2 LookDirection = Player.position - enemy.position;

        /*find the angle by using cotangent of direction, converting it from radians to degrees,
        and subtracting offset. finally, rotate the enemy itself*/
        enemy.rotation = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg - 90f;

        //move the enemy by its move direction and speed, as well as fixed delta time so the movements will be smooth
        enemy.MovePosition(enemy.position + MoveSpeed * LookDirection * Time.fixedDeltaTime);
    }
}
