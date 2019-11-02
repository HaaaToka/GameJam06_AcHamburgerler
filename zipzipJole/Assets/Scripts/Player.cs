using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float zaxis;
    bool isOn;
    // Start is called before the first frame update
    protected virtual void Move(string direction)
    {

    }
    protected virtual void Jump()
    {

    }
    private void Start()
    {
        zaxis = gameObject.transform.position.z;
    }
    private void Update()
    {
        isOn = gameObject.GetComponent<Animator>().GetBool("isOn");
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zaxis);
        if (isOn)
        {
            if (Input.GetKeyDown("space"))
            {
                Jump();
            }
            if (Input.GetKey("d"))
            {
                Move("right");
            }
            else if (Input.GetKey("a"))
            {
                Move("left");
            }
        }
    }

}
