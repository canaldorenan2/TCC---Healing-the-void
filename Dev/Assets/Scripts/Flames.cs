using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{

    ThirdPersonMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("ThirdPersonPlayer").GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            player.vida -= 10;
            Debug.Log("script flames: Entrou!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }

    private void par(Collider other)
    {
        if(other.tag == "Player")
        {
            player.vida -= 10;
            Debug.Log("script flames: Entrou!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }
}
