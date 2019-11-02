using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : Player
{
    public int moveFrc = 1;
    public int jumpMag = 20;
    // Start is called before the first frame update

    protected void Start()
    {
        base.Start();
        GetComponent<Rigidbody>().centerOfMass -= new Vector3(0, 1.5f, 0);
    }
    protected override void Move(string direction)
    {
        if (direction == "right")
        {
            gameObject.transform.position += new Vector3(moveFrc * Time.deltaTime, 0, 0);
        }
        if (direction == "left")
        {
            gameObject.transform.position -= new Vector3(moveFrc * Time.deltaTime, 0, 0);
        }
    }
    protected override void Jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(0, jumpMag, 0);
    }
}
