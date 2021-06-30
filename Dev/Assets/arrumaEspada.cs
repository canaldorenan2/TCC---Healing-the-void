using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrumaEspada : MonoBehaviour
{

    public GameObject espada_duplicada;

    public GameObject espada_original;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (this.tag == "Duplica")
            {
                espada_duplicada.SetActive(true);
                espada_original.SetActive(false);
            }

            if (this.tag == "Recupera")
            {
                espada_duplicada.SetActive(false);
                espada_original.SetActive(true);
            }


            
        }
    }
}
