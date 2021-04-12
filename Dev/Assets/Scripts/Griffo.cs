using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.AI;

public class Griffo : MonoBehaviour
{

    float vida, resistencia;
    int dano;
    float timer;

    bool tangivel;

    bool atacando;

    bool combate;

    bool longe = true;

    public bool katanaColetada = false;

    public ThirdPersonMovement player;

    public SofreDano scriptCalculaDano;

    public Animator animator;

    public GameObject destinoGenerico;

    public NavMeshAgent navMeshAgent;

    public bool playerAround;

    // Start is called before the first frame update
    void Start()
    {
        tangivel = false;
        atacando = false;
        combate = false;
        vida = 150;
        resistencia = 15;
        dano = 25;
        playerAround = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (katanaColetada && vida > 1)
        {
            if (longe)
            {
                SetDestino();
            }
            else
            {
                Luta();
            }
            
            
        }

        if (vida < 1)
        {
            this.gameObject.SetActive(false);
        }
    }



    private void SetDestino()
    {
        if (playerAround)
        {
            navMeshAgent.SetDestination(player.transform.position);
            
        }
        else
        {
            navMeshAgent.SetDestination(destinoGenerico.transform.position);
            animator.SetBool("Move", true);
        }
        

        if ((player.transform.position.x == this.transform.position.x) && (player.transform.position.y == this.transform.position.y))
        {
            longe = false;
        }


    }

    private void Luta()
    {
        

        AnimaIdle();
        Espera();
        Atacar();

    }
    private void AnimaIdle()
    {
        atacando = false;
        animator.SetBool("Idle", true);
        tangivel = true;
    }


    private void Espera()
    {
        int x = Random.Range(2, 3);

        while(timer < x)
        {
            timer += Time.deltaTime;
        }

    }

    private void Atacar()
    {
        tangivel = false;
        animator.SetBool("Idle", false);
        animator.SetBool("Ataque", true);
        atacando = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sofre Dano
        if(other.gameObject.name == "Katana")
        {
            if ((player.atacando == true) && (tangivel))
            {
                vida = scriptCalculaDano.CausaDano(player.dano, vida, resistencia);
            }
        }

        // Causa Dano

        if (other.gameObject.tag == "Player")
        {
            if (atacando)
            {
                player.vida = scriptCalculaDano.CausaDano(dano, player.vida, player.resistencia);
                atacando = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            longe = true;
        }
    }
}
