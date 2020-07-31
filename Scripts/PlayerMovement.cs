using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float MoveSpeed = 5f;
    public Rigidbody2D player;
    public Camera camera;
    Vector2 MoveDirection;
    Vector2 MousePosition;

    //inputs
    void Update() {
        //get direction in forms of -1, 0, or 1
        MoveDirection.x = Input.GetAxisRaw("Horizontal");
        MoveDirection.y = Input.GetAxisRaw("Vertical");

        //get mouse position in in game units, then convert to screen coordinates
        MousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    //outputs
    void FixedUpdate() {
        //move the player by its move direction and speed, as well as Time so the movements will be smooth
        player.MovePosition(player.position + MoveSpeed * MoveDirection * Time.fixedDeltaTime);

        //get a direction vector by subtracting player position from mouse position
        Vector2 LookDirection = MousePosition - player.position;
        /*then find the angle by using cotangent of direction, converting it from radians to degrees,
        and subtracting offset. finally, rotate the player itself*/
        player.rotation = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg - 90f;
    }
}
