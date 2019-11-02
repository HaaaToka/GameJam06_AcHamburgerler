using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulParticle : MonoBehaviour
{
    [SerializeField] GameObject particle;
    private Animator[] animators;
    Collider lastHit;

    // Start is called before the first frame update
    void Start()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        int len=0;
        for(int i = 0; i< players.Length; i++)
        {
            len++;
        }
        animators = new Animator[len];
        
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i] = players[i].GetComponent < Animator> ();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        soulActive();
    }
    void soulActive()
    {
        
        var mouse = Input.GetMouseButton(0);
        if (mouse)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                gameObject.transform.position = hitInfo.point;
                if (hitInfo.collider.tag == "Player" && Input.GetMouseButtonDown(0))
                {
                    Debug.Log("sda");
                    hitInfo.collider.GetComponent<Animator>().SetBool("isTapped", true);
                    particle.SetActive(true);
                }
                lastHit = hitInfo.collider;
                
            }
            
        }
        else
        {
            if (lastHit != null && lastHit.tag == "Player" && Input.GetMouseButtonUp(0))
            {
                
                foreach (Animator i in animators)
                {
                    i.SetBool("isOn", false);
                }
                lastHit.GetComponent<Animator>().SetBool("isOn", true);

            }
            foreach (Animator i in animators)
            {
                i.SetBool("isTapped", false);
            }
            particle.SetActive(false);
        }
    }
}
