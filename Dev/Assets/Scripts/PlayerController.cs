using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Não deixa o codigo rodar sem o animator
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    Rigidbody rigidbodyPlayer;

    Animator animacaoPlayer;

    Transform transformPlayer;

    float axiX, axiY;

    // Start is called before the first frame update
    void Start()
    {


        rigidbodyPlayer = transform.GetChild(0).GetComponent<Rigidbody>();

        animacaoPlayer = transform.GetChild(0).GetComponent<Animator>();


        transformPlayer = GetComponent<Transform>();

        
    }

    // Update is called once per frame
    void Update()
    {
        axiX = Input.GetAxis("Horizontal");
        axiY = Input.GetAxis("Vertical");

        Movimentacao();

    }



    void Movimentacao()
    {

        
        if (axiX != 0)
        {
            transform.Rotate(0, axiX * 10 * Time.deltaTime, 0);
        }

      
        // Frente

        
        if (Input.GetKey("w"))
        {

            animacaoPlayer.SetFloat("run", axiY);
            rigidbodyPlayer.AddForce(0, 100 * Time.deltaTime, 0);
        }else
        {
            animacaoPlayer.SetFloat("run", axiY);
        }

        /*
        // Vira para esquerda
        if (Input.GetKeyDown("a"))
        {
            animacaoPlayer.SetTrigger("run");
            transform.Rotate(0, -05, 0);
            rigidbodyPlayer.AddForce(0, 0.80f, 0);
        }

        // Vira para trás
        if (Input.GetKeyDown("s"))
        {
            animacaoPlayer.SetTrigger("run");
            transform.Rotate(0, -45, 0);
            rigidbodyPlayer.AddForce(0, 0.80f, 0);
        }

        // Move para direita
        if (Input.GetKeyDown("d"))
        {
            animacaoPlayer.SetTrigger("run");
            transform.Rotate(0, -5, 0);
            rigidbodyPlayer.AddForce(0, 0.80f, 0);
        }
        */

        // Pula
        if (Input.GetKeyDown("space"))
        {
            animacaoPlayer.SetBool("jump", true);
            rigidbodyPlayer.AddForce(0, 0, 10);
        }
        else
        {
            animacaoPlayer.SetBool("jump", false);
        }

        // Ataque 1
        if (Input.GetMouseButton(0))
        {
            animacaoPlayer.SetBool("slash1", true);
            rigidbodyPlayer.AddForce(0, 0.1f, 0);
        }
        else
        {
            animacaoPlayer.SetBool("slash1", false);
        }

        // Verifica se está colidindo com o chão
        //if (rigidbodyPlayer.transform.)

        
    }
}
