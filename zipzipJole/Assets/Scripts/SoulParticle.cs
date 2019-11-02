using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulParticle : MonoBehaviour
{
    public float particleCount = 100f;
    public float loseMultiplier = 3f;
    [SerializeField] GameObject particle;
    private Text particleText;
    private Animator[] animators;
    Collider lastHit;

    // Start is called before the first frame update
    void Start()
    {
        particleText = GameObject.Find("particleText").GetComponent<Text>();
        particleText.text = Mathf.Ceil(particleCount).ToString();
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
                if (hitInfo.collider.tag != "rayPlane" && hitInfo.collider.tag != "Player")
                {
                    if(particle.GetComponent<ParticleSystem>().isPlaying)
                        particleCount -= loseMultiplier * Time.deltaTime;
                    particleText.text = Mathf.Ceil(particleCount).ToString();
                }
                gameObject.transform.position = hitInfo.point;
                if (hitInfo.collider.tag == "Player" && Input.GetMouseButtonDown(0) && hitInfo.collider.GetComponent<Animator>().GetBool("isOn"))
                {
                    hitInfo.collider.GetComponent<Animator>().SetBool("isTapped", true);
                    particle.SetActive(true);
                }
                lastHit = hitInfo.collider;
                
            }
            
        }
        else
        {
            if (lastHit != null && lastHit.tag == "Player" && Input.GetMouseButtonUp(0) && particle.GetComponent<ParticleSystem>().isPlaying)
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
