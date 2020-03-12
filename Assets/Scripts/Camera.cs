using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float xMargin = 1.5f;     // closeness to edge of screen before camera movement
    public float yMargin = 5f;
    public float xSmooth = 1.5f;     //smooth value
    public float ySmooth = 1.5f;
    public Vector2 maxXandY;
    public Vector2 minXandY;
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        //find player
        player = GameObject.Find("chemi 1_0").transform;


        //error message for programmer, if unity can't find the program
        if (player == null)
        {
            Debug.Log("Where did it go");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float targetX = transform.position.x;  //checks cameras x and y values
        float targetY = transform.position.y;
        if (CheckXMargin()) //returns true if camera needs to move x
        {
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        }
        if (CheckYMargin()) //returns true if camera needs to move y
        {
            targetY = Mathf.Lerp(transform.position.y, player.position.y, xSmooth * Time.deltaTime);
        }

        targetY = Mathf.Clamp(targetY, minXandY.y, maxXandY.y);
        targetX = Mathf.Clamp(targetX, minXandY.x, maxXandY.x);

        transform.position = new Vector3(targetX, targetY, transform.position.z);

    }


    bool CheckXMargin()
    {
        //check if character has moved horizontally into x margin
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin()
    {
        //check if character has moved horizontally into y margin
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }


}
