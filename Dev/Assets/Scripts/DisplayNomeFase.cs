using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayNomeFase : MonoBehaviour
{
    public GameObject Texto;
    

    bool display;
    float timer;

    private void Start()
    {
        display = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (display)
        {
            timer += Time.deltaTime;

            if (timer > 5)
            {
                Texto.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if 
            (other.tag == "Player")
        {
            if (!display)
            {
                Texto.SetActive(true);
                display = true;
            }
        }
    }
}
