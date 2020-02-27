using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMoveScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    public Vector2 move;
    private Rigidbody2D rb2d;





    // Start is called before the first frame update
    void Start()
    {
        //define movement of projectile

    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(speed.x * direction.x, speed.y * direction.y);
        if (rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        rb2d.velocity = move;


    }
}
