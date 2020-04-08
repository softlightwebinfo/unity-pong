using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float speed = 25.0f;
    public string axis = "Vertical";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (GameManager.sharedInstance.gameStarted)
        {
            float v = Input.GetAxisRaw(this.axis);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, this.speed * v);
        }
    }
}
