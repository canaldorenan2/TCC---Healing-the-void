using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Colossus : MonoBehaviour
{
    public bool vulneravel;
    public bool playerNaArena, proximo, ficaVulneravel;
    public Slider sliderVida;
    int aux;
    public int vida;
    public NavMeshAgent navMeshAgent;

    public GameObject player;
    public GameObject arena;
    public GameObject destinoGenerico;
    public GameObject hudBoss;
    public GameObject hudExtensao;

    public Animator animator;

    [Header("Audios")]
    public AudioSource ataque;
    public AudioSource ataqueForte;
    public AudioSource hit;
    public AudioSource death;
    public AudioSource risada;

    float timer = 0;
    float tempoEspera = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        sliderVida.value = 600;
        vulneravel = false;
        playerNaArena = false;
        ficaVulneravel = false;
        proximo = false;
        aux = 0;
        

        navMeshAgent.SetDestination(destinoGenerico.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //navMeshAgent.SetDestination(player.transform.position);

        if (sliderVida.value < 1)
        {
            hudBoss.SetActive(false);
            hudExtensao.SetActive(false);
            this.gameObject.SetActive(false);
            Destroy(this, 5);
        }

        if (timer > tempoEspera)
        {

            timer = 0;
            tempoEspera = Random.Range(0.62f, 2.03f);
            //ataque.Stop();

            if ((playerNaArena) && (!proximo))
            {
                Destino();
            }
            else
                if ((playerNaArena) && (proximo))
            {
                animator.SetBool("Ataque", false);
                animator.SetBool("Walk", false);
                animator.SetBool("Run", false);
                ataque.Play();
                animator.SetBool("Ataque", true);

            }
                else
            {
                navMeshAgent.SetDestination(destinoGenerico.transform.position);
                animator.SetBool("Run", false);
                animator.SetBool("Walk", true);
                
            }

        }
        else
        {
            timer += Time.deltaTime;
            
        }

        // setar destino no player
        // adicionar um ao contador quando o player sair da area de ataque
        // setar um valor minimo de intervalo
        // depois de 3 vezez deixar o boss vulnerável

    }

    private void OnTriggerEnter(Collider other)
    {
        navMeshAgent.SetDestination(this.transform.position);
        timer = timer + 10.10f;

        animator.SetBool("Run", false);

        proximo = true;

        //animator.SetBool("Run", false);

        //navMeshAgent.Stop();

        if (vulneravel)
        {
            if (other.tag == "Player")
            {

            }
        }
        else
        {
            SetForAtack();
            animator.SetBool("Ataque", true);
            ataque.Play();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Ataque", false);
        proximo = false;

        if (other.tag == "Player")
        {
            Destino();
        }
    }

    public void SetForAtack()
    {
        Destino();
        transform.Rotate(10, 0, 0);
    }

    public void Destino()
    {
        navMeshAgent.SetDestination(player.transform.position);
        animator.SetBool("Run", true);
        animator.SetBool("Walk", false);
    }
}
