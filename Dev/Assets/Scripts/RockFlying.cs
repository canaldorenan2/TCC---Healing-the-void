using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFlying : MonoBehaviour
{
    //public Transform rockGenerated;
    public GameObject rockGenerated;

    public float time, velocidade;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (time > 5)
        {
            
            Instantiate(rockGenerated, this.gameObject.transform, this.transform);
            //rockGenerated.Translate(0,0,0);
            time = 0;
        }
            time = time + Time.deltaTime;

    }
}
