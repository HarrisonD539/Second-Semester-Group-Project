using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //global
    public Transform shotPrefab;
    //wait period between shots
    public float shootingRate = 0.25f;
    //the actual cooldoen required for the weapon
    public float shootCooldown;





    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }


    public void Attack(bool isEnemy)
    {
        if (CanAttack)       //check if attack connects
        {
            //shoot delay
            shootCooldown = shootingRate;
            //create a clone of the projectile
            var shotTransform = Instantiate(shotPrefab) as Transform;
            //Start weapon at location
            shotTransform.position = transform.position;
            //assigns shot logic
            Shot shot = shotTransform.gameObject.GetComponent<Shot>();

            //make it move
            ShotMoveScript move = shotTransform.gameObject.GetComponent<ShotMoveScript>();

            Move facingDirection = GetComponent<Move>();


            //if there is a projectile
            if (move != null)
            {
                if (facingDirection.facingRight)
                {
                    move.direction = this.transform.right;
                }
                else
                {
                    move.direction = this.transform.right * -1;
                }
            }

        }
    }
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }

}



