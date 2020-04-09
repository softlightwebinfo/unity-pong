using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float speed = 25.0f;

    private void FixedUpdate()
    {
        float mov = Input.GetAxisRaw("Horizontal");
        //GetComponent<Rigidbody2D>().velocity = new Vector2(mov * this.speed, 0);
        GetComponent<Rigidbody2D>().velocity = Vector2.right * mov * this.speed;
    }
}
