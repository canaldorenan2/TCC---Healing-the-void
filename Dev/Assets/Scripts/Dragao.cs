using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragao : MonoBehaviour
{
    public int vida = 10;

    private NavMeshAgent navMeshAgent;

    public Animator animator;

    public Transform referencia;

    public int controlaDestino;

    public bool playerAtacavel, localDaTreta, setadoLocalDaTreta;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.transform.GetComponent<Animator>();

        navMeshAgent = GetComponent<NavMeshAgent>();

        controlaDestino = 0;
        GeraDestino();

        playerAtacavel = false;
        localDaTreta = false;

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
            }
            else
            {
                navMeshAgent.SetDestination(referencia.position);
            }
        }
        else
        {
            if (!localDaTreta)
            {
                if ((navMeshAgent.transform.position.x == referencia.position.x) && (navMeshAgent.transform.position.z == referencia.position.z))
                {
                    animator.SetBool("PlayerAround", true);
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

            }
        }



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


}