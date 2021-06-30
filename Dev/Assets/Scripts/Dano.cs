using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entrou");

        if (other.tag == "Griff")
        {
            Debug.Log("Atacado - Griff");

            GameObject.Find("HIPPOGRIFF_LEGACY").GetComponent<Griffo>().vida -= 7;
        }

        if (other.tag == "SamuraiInimigo")
        {
            Debug.Log("Atacado - SamuraiInimigo");
            GameObject.Find("Samurai_Z").GetComponent<Samuzai>().vida -= 5;
        }

        if (other.tag == "Dragon")
        {
            Debug.Log("Atacado - Dragon");
            GameObject.Find("Dragon").GetComponent<Dragao>().vida -= 1;
        }

        if (other.tag == "Colossus")
        {
            Debug.Log("Atacado - Colossus");
            GameObject.Find("Colossus").GetComponent<Colossus>().vida -= 3;
        }
    }
}
