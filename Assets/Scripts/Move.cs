using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    //declare global variables
    private Rigidbody2D toad;
    private float move;
    public float Speed = 7f;
    private Animator anim;
    public bool facingRight = false;
    public float jumpPower = 7f;
    public enum State
    {
        normal,
        jumping
    }
    public State state;





    // Start is called before the first frame update
    void Start() //loads when the associated scene is loaded
    {
        toad = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


  



        move = Input.GetAxis("Horizontal");

        if (move > 0 && facingRight == false)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }





        move = Input.GetAxis("Horizontal");
        toad.velocity = new Vector2(move * Speed, toad.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.up * jumpPower * Time.deltaTime);
        }
        {
            if (Input.GetButtonDown("Jump")) Jump();
        }



        //has a request to fire weapon
        bool shoot = Input.GetKeyDown(KeyCode.Mouse0);

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }
    }
    void Flip()
    {
        facingRight = !facingRight;         //flip facing right data
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.up * jumpPower * Time.deltaTime);
        }
        {
            if (Input.GetButtonDown("Jump")) Jump();
        }
        state = State.jumping;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground" && state == State.jumping)
        {
            state = State.normal;
        }
    }

} //end of class