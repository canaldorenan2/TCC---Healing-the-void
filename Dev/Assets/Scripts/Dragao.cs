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

    // Start is called before the first frame update
    void Start()
    {
        animator = this.transform.GetComponent<Animator>();

        navMeshAgent = GetComponent<NavMeshAgent>();

        referencia = transform.Find("Referencia").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((navMeshAgent.transform.position.x == referencia.position.x) && (navMeshAgent.transform.position.z == referencia.position.z))
        {
            Voar();
        }
        else
        {
            navMeshAgent.SetDestination(referencia.position);
        }
        /*
        if(!animator.GetBool("PlayerAround"))
        {
            
            
        }*/
    }

    private void Voar()
    {
        Vector3 posicaoRef = new Vector3(Random.Range(-130,-72), 0, Random.Range(-70, 8));

        referencia.Translate(posicaoRef);

        // -130 as - 72;
    }
}
