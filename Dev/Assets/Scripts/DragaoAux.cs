using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragaoAux : MonoBehaviour
{
    public Dragao dragao;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dragao.playerAtacavel = true;
            Debug.Log("Entrou!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
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
