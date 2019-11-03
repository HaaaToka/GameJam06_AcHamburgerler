using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float time;
    float zaxis;
    bool isOn;
    Button right;
    Button left;
    Button jump;
    CharacterController controller;
    // Start is called before the first frame update
    public virtual void Move(string direction)
    {
        if (!isOn)
            return;
    }
    public virtual void Jump()
    {
        if (!isOn)
            return;
    }
    protected void Start()
    {
        right = GameObject.Find("Right").GetComponent<Button>();
        left = GameObject.Find("Left").GetComponent<Button>();
        jump = GameObject.Find("Jump").GetComponent<Button>();
        time = Time.time;
        controller = GetComponent<CharacterController>();
        zaxis = gameObject.transform.position.z;
        
    }
    protected virtual void Idle()
    {

    }
    protected void Update()
    {


        isOn = gameObject.GetComponent<Animator>().GetBool("isOn");
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zaxis);
        if (isOn)
        {


            /*if (Input.GetKeyDown("space"))
            {
                if (time < Time.time - 1)
                {
                    Jump();
                    time = Time.time;
                }
            }
            if (Input.GetKey("d"))
            {

                Move("right");
            }
            else if (Input.GetKey("a"))
            {
                Move("left");
            }
            else
            {
                Idle();
            }*/
            if (jump.GetComponent<UIPresser>().pressed || Input.GetKeyDown("space"))
            {

                if (time < Time.time - 1)
                {
                    Jump();
                    time = Time.time;
                }
            }
        if (right.GetComponent<UIPresser>().pressed || Input.GetKey("d"))
        {

            Move("right");
        }
        else if (left.GetComponent<UIPresser>().pressed || Input.GetKey("a"))
        {
            Move("left");
        }
        else
        {
            Idle();
        }
    }
          
        }
        
    }


