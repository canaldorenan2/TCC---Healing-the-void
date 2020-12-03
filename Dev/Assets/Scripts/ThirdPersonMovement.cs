using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController characterController;

    public float speed = 6;

    float horizontal, vertical, targetAngle, anguloFilho;

    public Transform camera;

    Vector3 moveDirection;

    Vector3 direction, gravidade;

    public Animator animator;

    Transform pai, filho;

    public bool runAux, jump, colidindoTerreno, flyJump, primeiraRodada, ataque1;

    public GameObject playerObject;

    public float velocidadeAceleracao, timer1, timer2;


    private void Start()
    {
        pai = gameObject.transform;
        filho = gameObject.transform.GetChild(0);
        characterController = GetComponent<CharacterController>();
        velocidadeAceleracao = -10.0f;
        colidindoTerreno = false;
        flyJump = false;
        jump = true;
        ataque1 = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (!characterController.isGrounded)
        {
            if (flyJump)
            {
                velocidadeAceleracao += 1.2f;
            }
            Vector3 pulo = new Vector3(0, velocidadeAceleracao * Time.deltaTime, 0);
            characterController.Move(pulo);
            velocidadeAceleracao -= 0.79f;
        }


        // Verifica o tamanho do vector
        if (direction.magnitude > 0.1f)
        {
            // Aqui ele vai pegar a tangente de x sobre y, resultando em um radiano anti horário
            targetAngle = Mathf.Atan2(direction.x, direction.z);

            // Transforma o valor de radianos para graus
            targetAngle = targetAngle * Mathf.Rad2Deg;

            // Pega a rotação de Y
            targetAngle = targetAngle + camera.eulerAngles.y;

            // Aplica a rotação 
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Guarda o valor para resetar a animação no lugar correto
            anguloFilho = targetAngle;

            // Converte a rotação em direção
            moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            // Realiza o movimento 
            characterController.Move(moveDirection * speed * Time.deltaTime);
        }

        ControleAnimacao();

        if (ataque1)
        {
            ControlaAtaque1();
        }


    }

    void ControlaAtaque1()
    {
        if (timer1 < 0.7f)
        {
            timer1 = timer1 + Time.deltaTime;
        }
        else
        {
            if (timer1 > 0)
            {
                animator.SetBool("slash1", false);
                timer1 = 0;
            }


            if (timer2 > 0 && timer2 < 0.8)
            {
                timer2 += Time.deltaTime;
            }
            else
            {
                animator.SetBool("slash1Continuos", false);
                ataque1 = false;
                timer2 = 0;
            }
        }
    }

    void ControleAnimacao()
    {


        // Controla a animação de correr
        if (direction.magnitude > 0.1f)
        {
            animator.SetBool("run", true);
            runAux = true;
        }
        else
        {
            if (runAux == true)
            {
                animator.SetBool("run", false);
                filho.Rotate(0, 0, 0);
                runAux = false;
            }
        }

        // Controla o pulo
        if (Input.GetKeyDown("space"))
        {

            jump = true;
            velocidadeAceleracao = 10f;
            Vector3 pulo = new Vector3(0, velocidadeAceleracao * Time.deltaTime, 0);
            characterController.Move(pulo);
            animator.SetBool("jump", true);


        }

        // controla a queda
        if (characterController.isGrounded)
        {
            if (!colidindoTerreno)
            {
                colidindoTerreno = true;
            }
            jump = false;
            velocidadeAceleracao = 2.1f;
            animator.SetBool("jump", false);

        }

        // Controla o ataque 1

        if (Input.GetMouseButtonDown(0))
        {
            if (!animator.GetBool("slash1"))
            {
                animator.SetBool("slash1", true);
                timer1 = 0;
                ataque1 = true;
            }

            if (animator.GetBool("slash1") && !animator.GetBool("slash1Continuos") && timer1 > 0.1f)
            {
                animator.SetBool("slash1Continuos", true);
                timer2 = 0.02f;
                animator.SetBool("slash1", false);
            }

            if (animator.GetBool("slash1") && animator.GetBool("slash1Continuos") && timer2 > 0.2f)
            {
                animator.SetBool("slash1End", true);
                animator.SetBool("slash1", false);
                animator.SetBool("slash1Continuos", false);
                timer1 = 10;
                timer2 = 10;
            }


        }


        if (!Input.anyKey)
        {
            //animator.setIdle true;
        }

    }

    float Acelera(float velocidadeDeAceleracao)
    {
        velocidadeDeAceleracao = velocidadeDeAceleracao - 0.1f;

        if (velocidadeDeAceleracao >= 0.0f)
        {
            velocidadeDeAceleracao = velocidadeDeAceleracao - 0.1f;
        }
        else
        {
            velocidadeDeAceleracao = velocidadeDeAceleracao - 0.2f;
        }

        return velocidadeDeAceleracao;
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Terrain")
        {
            colidindoTerreno = true;
            velocidadeAceleracao = 1;
            if (jump)
            {
                jump = false;
                velocidadeAceleracao = 11.1f;
            }
        }
    }
    */
}
