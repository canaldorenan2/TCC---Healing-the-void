using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoSamuzai : MonoBehaviour
{
    public ThirdPersonMovement player;

    public Samuzai samuzai;

    int dano;
    void Start()
    {
        if (!player) player = GameObject.Find("ThirdPersonPlayer").GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (samuzai.animator.GetBool("Attack"))
            {
                dano = 25;
                player.vida = player.vida - (dano - (player.resistencia / 4));
            }
        }
    }
}
