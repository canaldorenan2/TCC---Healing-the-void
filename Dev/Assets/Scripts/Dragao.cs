using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Dragao : MonoBehaviour
{
    public int vida = 100;

    private NavMeshAgent navMeshAgent;

    public Animator animator;

    public Transform referencia;

    public Transform player;

    public int controlaDestino;

    public bool playerAtacavel, localDaTreta, setadoLocalDaTreta, vivo, noPit;

    public GameObject fogoPrefabe, instanciaFogoPrefabe;

    float timer = 0;

    public GameObject antigoDragaoTxt;

    public Slider sliderDrag;



    // Start is called before the first frame update
    void Start()
    {
        animator = this.transform.GetComponent<Animator>();

        navMeshAgent = GetComponent<NavMeshAgent>();

        controlaDestino = 0;
        GeraDestino();

        playerAtacavel = false;
        localDaTreta = false;
        vivo = true;
        noPit = false;
        vida = 200;
        sliderDrag.value = vida;

        //referencia = transform.Find("Referencia").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerAtacavel)
        {
            if ((navMeshAgent.transform.position.x == referencia.position.x) && (navMeshAgent.transform.position.z == referencia.position.z))
            {
                //Voar();
                GeraDestino();
                noPit = false;
            }
            else
            {
                if (!noPit)
                {
                    navMeshAgent.SetDestination(referencia.position);
                }
                else
                {

                }

                if(navMeshAgent.transform.position == referencia.position)
                {
                    //noPit = true;
                }
            }
        }
        else
        {
            if (!localDaTreta)
            {
                if ((navMeshAgent.transform.position.x == referencia.position.x) && (navMeshAgent.transform.position.z == referencia.position.z))
                {
                    animator.SetBool("PlayerAround", true);
                    noPit = true;
                }
                else
                {
                    if (!setadoLocalDaTreta)
                    {
                        referencia.transform.position = new Vector3(-96, 132, -50);
                        controlaDestino = 0;
                        setadoLocalDaTreta = true;
                    }
                    navMeshAgent.SetDestination(referencia.position);
                }

            }
            else
            {
                //   navMeshAgent.SetDestination(player.position);

            }

            
        }

        if (vida < 1)
        {
            vivo = false;
            antigoDragaoTxt.SetActive(false);
            Destroy(this);

        }

        if (noPit)
        {
            antigoDragaoTxt.gameObject.SetActive(true);
            Gira();
            CospeFogo();
        }
        else
        {
            animator.SetBool("CospeFogo", false);
            timer = 0;
        }

        sliderDrag.value = vida;

    }

    private void CospeFogo()
    {
        timer += Time.deltaTime;

        if (timer > 11)
        {
            instanciaFogoPrefabe = Instantiate(fogoPrefabe, this.transform);
            Destroy(instanciaFogoPrefabe, 10.5f);
            animator.SetBool("CospeFogo", true);
            timer = -10;
        }
    }

    private void Gira()
    {

        Vector3 posicaoPlayer = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y, player.gameObject.transform.position.z);

        transform.LookAt(posicaoPlayer);
    }

    private void Voar()
    {
        Vector3 posicaoRef = new Vector3(Random.Range(-130, -72), 0, Random.Range(-70, 8));

        referencia.Translate(posicaoRef);

        // -130 as - 72;
    }

    void GeraDestino()
    {
        controlaDestino++;

        float posicaox = 0, posicaoz = 0, posicaoy = 0;

        switch (controlaDestino)
        {
            case 1:
                posicaox = Random.Range(0, 74);
                posicaoz = Random.Range(0, 53);
                posicaox += -70;
                posicaoz += -128;
                posicaoy = 185;
                setadoLocalDaTreta = false;
                break;
            case 2:
                posicaox = -6;
                posicaoz = -24;
                posicaoy = 185;
                break;
            case 3:
                posicaox = -44;
                posicaoz = 19;
                posicaoy = 185;
                break;
            case 4:
                posicaox = Random.Range(0, 129);
                posicaoz = Random.Range(0, 152);

                float adicional = (0.28f) * posicaox;

                posicaox += -207;
                posicaoz += -125;

                posicaoy = 149 + adicional;
                controlaDestino = 0;
                break;
        }

        referencia.transform.position = new Vector3(posicaox, posicaoy, posicaoz);


    }

    private void OnParticleCollision(GameObject other)
    {
        
            vida -= 3;
           
            Debug.Log("script dragao: Entrou!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        
    }
}