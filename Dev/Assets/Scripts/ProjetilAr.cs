using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilAr : MonoBehaviour
{

    Dragao dragao;
    Colossus colossus;

    public int velocidade = 1;

    // Start is called before the first frame update
    void Start()
    {
        dragao = GameObject.Find("Dragon").GetComponent<Dragao>();
        colossus = GameObject.Find("Colossus").GetComponent<Colossus>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(velocidade, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Trigger enter");

        if (other.tag == "Dragon")
        {
            dragao.vida -= 10;
        }

        if (other.tag == "Colossus")
        {
            Debug.Log("Atingiu colossus");
            colossus.vida -= 5;
        }
    }
}
