using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextingScript : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;
    public GameObject Panel6;
    public GameObject Panel7;
    public GameObject Panel8;
    // Start is called before the first frame update
    void Start()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
        Panel5.SetActive(false);
        Panel6.SetActive(false);
        Panel7.SetActive(false);
        Panel8.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Text1")//third floor after spawn
        {
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
            Panel8.SetActive(false);
        }
        if (other.tag == "Text2")//third floor closer to key
        {
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
            Panel8.SetActive(false);
        }
        if (other.tag == "Text3")//second floor near forced light 
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(true);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
            Panel8.SetActive(false);
        }
        if (other.tag == "Text4")//first floor (in staircase)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Panel4.SetActive(true);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
            Panel8.SetActive(false);
        }
        if (other.tag == "Text5")//ground floor as you leave the stairs
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(true);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
            Panel8.SetActive(false);
        }
        if (other.tag == "Text6")//RIDDLE (ground floor)
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(true);
            Panel7.SetActive(false);
            Panel8.SetActive(false);
        }
        if (other.tag == "Text7")
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(true);
            Panel8.SetActive(false);
        }
        if (other.tag == "Text8")
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            Panel5.SetActive(false);
            Panel6.SetActive(false);
            Panel7.SetActive(false);
            Panel8.SetActive(true);
        }

        other.enabled = false;
    }
}
