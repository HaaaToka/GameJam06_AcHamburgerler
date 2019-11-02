using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadScript : MonoBehaviour
{
    public GameObject[] stars;
    float star1;
    float star2;
    float star3;
    bool Lerp = false;
    public GameObject SuccessPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lerp)
        {
            SuccessInit();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            if (!Lerp)
            {
                gameObject.GetComponent<Animator>().SetTrigger("pressTrigger");
                Success();
            }
        }
    }
    int score;
    int loop = 5;
    
    void Success()
    {
        SuccessPanel.SetActive(true);
        score = Int32.Parse(GameObject.Find("particleText").GetComponent<Text>().text);
        
        
        Debug.Log(stars[0].GetComponent<Image>().fillAmount);
        //if (stars[0].GetComponent<Image>().fillAmount < 0.98f && stars[0].GetComponent<Image>().fillAmount < score / 30)
        Lerp = true;

    }
    
    void SuccessInit()
    {
        if (score < 30)
        {
            
        }
        else if (score < 60)
        {
            stars[0].SetActive(true);
        }
        else if (score < 90)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }
}
