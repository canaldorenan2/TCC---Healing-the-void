using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetKatana : MonoBehaviour
{
    public Text text;
    //public AudioClip flauta;
    public AudioSource flauta1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            text.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                flauta1.Play();
                this.gameObject.transform.Translate(0, -10, 0);
                //this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
    }
}
