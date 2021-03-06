using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossset : MonoBehaviour

{

    public Terrain terreno;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            terreno.gameObject.SetActive(false);
            other.gameObject.transform.Translate(10 * Time.deltaTime, 1 * Time.deltaTime, 10 * Time.deltaTime);
            Destroy(this, 2);
        }
    }
}
