using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour { 

    private float movePlayer;
    public float speed = -1f;
    private Rigidbody2D box;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        box = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
    }

    // Update is called once per frame
    void Update()
    {
    }
        void FixedUpdate () {
            movePlayer = 1;
            box.velocity = new Vector2(movePlayer * speed, box.velocity.y);



        bool shoot = true;

       /* if (shoot)
        {
            EnemyWeapon weapon = GetComponent<EnemyWeapon>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }
        */

    }
            
    
    private void Flip()
    {
        facingRight = !facingRight;         //flip facing right data
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    } 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Boundry")
        {
            speed *= -1;
            Flip();
        }
        else if (col.gameObject.name == "Boundry 2")
        {
            speed *= -1;
            Flip();
        }
    }


}
