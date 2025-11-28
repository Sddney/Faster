using UnityEngine;
using System;

public class player_movement : MonoBehaviour
{
    public float speed = 7f;
    public float speed_decrease = 0.1f;

    private Rigidbody2D rb;

    private Vector2 movement;

    private Vector3[] player1_positions = new Vector3[3];

    private Vector3 velocity = Vector3.zero;

    public bool moving = false;

    public float position_count = 1;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player1_positions[0] = new Vector3(-2f, -2.65f, 0);
        player1_positions[1] = new Vector3(0, -2.65f, 0);
        player1_positions[2] = new Vector3(2f, -2.65f, 0);
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        transform.position = Vector3.SmoothDamp(transform.position, player1_positions[(int)position_count], ref velocity, speed_decrease, speed);
        if (movement.x != 0 && moving == false)
        {
            position_count += movement.x;
            moving = true;
        }
        else if (movement.x == 0)
        {
            moving = false;
            speed = 7f;

        }

        if (position_count > 2)
        {
            position_count = 2;
        }
        else if (position_count < 0)
        {
            position_count = 0;
        }

    }
}
