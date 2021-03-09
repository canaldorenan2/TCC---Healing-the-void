using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Colossus : MonoBehaviour
{
    public bool vulneravel;
    public bool temAlvo;
    public Slider sliderVida;
    int aux;
    public int vida;
    public NavMeshAgent navMeshAgent;

    public GameObject player;
    public GameObject arena;
    public GameObject destinoGenerico;

    public Animator animator;

    [Header ("Audios")]
    public AudioSource ataque;
    public AudioSource ataqueForte;
    public AudioSource hit;
    public AudioSource death;
    public AudioSource risada;

    float timer = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        sliderVida.value = 600;
        vulneravel = false;
        temAlvo = false;
        aux = 0;

        navMeshAgent.SetDestination(destinoGenerico.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);


        if (timer > 3)
        {
            timer += Time.deltaTime;

        }

        // setar destino no player
        // adicionar um ao contador quando o player sair da area de ataque
        // setar um valor minimo de intervalo
        // depois de 3 vezez deixar o boss vulnerável
        
    }

    private void FicaVulneravel()
    {
        animator.SetBool("Ataque", true);
        ataque.Play();
    }

    private void ExecutaAcao()
    {
        if (this.transform.position != player.transform.position)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        navMeshAgent.SetDestination(this.transform.position);
        animator.SetBool("Run", false);

        navMeshAgent.Stop();

        if (vulneravel)
        {
            if (other.tag == "Player")
            {

            }
        }
        else
        {
                animator.SetBool("Ataque", true);
                ataque.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Ataque", false);

        if (other.tag == "Player")
        {
            Destino();
        }
    }

    public void Destino()
    {
            navMeshAgent.SetDestination(player.transform.position);
            temAlvo = true;
    }
}
