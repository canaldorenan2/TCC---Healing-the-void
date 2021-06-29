using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Samuzai : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    public GameObject posicaoNeutra;

    public GameObject player;

    public bool playerAround, nearPlayer;

    public Animator animator;

    public float vida;

    float timer = 0;

    void Start()
    {
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

        vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerAround)
        {   
            
            // Verifica se a posição do Samuzai em x e z é a mesma do destino generico
            if ((this.gameObject.transform.position.x == posicaoNeutra.transform.position.x) && (this.gameObject.transform.position.z == posicaoNeutra.transform.position.z))
            {
                Anima(0);
            }
            else
            {
                navMeshAgent.SetDestination(posicaoNeutra.transform.position);
                Anima(1);
            }
        }
        else
        {
            navMeshAgent.SetDestination(player.transform.position);

            if (nearPlayer)
            {
                Anima(3);
            }
        }


        if (vida < 0)
        {
            Destroy(this);
        }
    }

    // animações do Samuzai
    public void Anima(int n)
    {

        timer += Time.deltaTime;

        if (timer > 2.5f || n != 3)
        {
            
            switch (n)
            {
                case 0: // Idle
                    animator.SetBool("Walk", false);
                    animator.SetBool("Run", false);
                    animator.SetBool("Attack", false);
                    break;

                case 1: // Walk
                    animator.SetBool("Walk", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("Attack", false);
                    break;
                case 2: // Run
                    animator.SetBool("Run", true);
                    animator.SetBool("Walk", false);
                    animator.SetBool("Attack", false);
                    break;
                case 3: // Atack
                    animator.SetBool("Attack", true);
                    animator.SetBool("Walk", false);
                    animator.SetBool("Run", false);
                    break;
            }
            timer = 0;
        }
        else
        {
            if (timer > 1 && timer < 2.5f ){
                animator.SetBool("Attack", false);
            }
        }
        
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            nearPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nearPlayer = false;
        }
    }
}
