using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausaDano : MonoBehaviour
{
    Dragao dragon;
    

    void Start()
    {
        dragon = GameObject.Find("Dragon").GetComponent<Dragao>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dragon")
        {
            dragon.vida = dragon.vida - 5;
            dragon.animator.SetInteger("Life", -5);
        }
    }
}
