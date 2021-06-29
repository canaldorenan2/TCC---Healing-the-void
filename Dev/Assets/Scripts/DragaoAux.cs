using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragaoAux : MonoBehaviour
{
    public Dragao dragao;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dragao.playerAtacavel = true;
            //Debug.Log("Entrou!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dragao.playerAtacavel = false;
        }
    }
}
