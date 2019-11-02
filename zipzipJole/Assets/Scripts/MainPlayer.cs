using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : Player
{
    public int moveFrc = 1;
    public int jumpMag = 20;
    // Start is called before the first frame update
    [SerializeField] GameObject enivici;
    private Animator animator;
    protected void Start()
    {
        
        base.Start();
        animator = GetComponent<Animator>();
        GetComponent<Rigidbody>().centerOfMass -= new Vector3(0, 1.5f, 0);
    }
    protected override void Move(string direction)
    {
        if (direction == "right")
        {
            gameObject.transform.position += new Vector3(moveFrc * Time.deltaTime, 0, 0);
            animator.SetBool("walking", true);
            enivici.SetActive(false);
        }
        else if (direction == "left")
        {
            gameObject.transform.position -= new Vector3(moveFrc * Time.deltaTime, 0, 0);
            animator.SetBool("walking", true);
            enivici.SetActive(true);
        }
    }
    protected override void Jump()
    {
        
        animator.SetTrigger("jumped");
        Invoke("DoSomething", 0.5f);
        gameObject.GetComponent<Rigidbody>().AddForce(0, jumpMag, 0);
    }
    protected override void Idle()
    {
        animator.SetBool("walking", false);
        enivici.SetActive(false);
    }
}
