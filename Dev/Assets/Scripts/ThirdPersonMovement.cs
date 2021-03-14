using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController characterController;

    public Animator animator;

    public Transform camera;

    public GameObject playerObject;

    Vector3 moveDirection;

    Vector3 direction;

    public float velocidadeAceleracao, timer1, timer2, timer3, contadorRegen, tempoParaRegen;

    public float speed = 18;

    public int vida = 100;

    public int dano = 10;
    public int resistencia = 10;
    public int lifeRegen = 1;

    float horizontal, vertical, targetAngle;

    public bool runAux, jump, colidindoTerreno, flyJump, primeiraRodada, ataque1, ataque2, atacando;

    public GameObject katana;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        velocidadeAceleracao = -10.0f;
        colidindoTerreno = false;
        flyJump = false;
        jump = true;
        ataque1 = false;
        speed = 10;
        vida = 80;
        



        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            katana.SetActive(false);
            tempoParaRegen = 10;

        }

        contadorRegen = tempoParaRegen;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Regeneração de Vida
        {
            if (Time.fixedTime > contadorRegen)
            {
                vida += lifeRegen;
                contadorRegen = Time.fixedTime + tempoParaRegen;
            }
        }

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

        if (vida > 101)
        {
            vida = 100;
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
            if (timer2 == 0)
            {
                animator.SetBool("slash1", false);
                ataque1 = false;
                timer1 = 0;
            }

            if (timer2 > 0 && timer2 < 0.8f)
            {
                timer2 += Time.deltaTime;
            }
            else
            {
                if (timer3 > 0 && timer3 < 0.8f)
                {
                    timer3 += Time.deltaTime;
                }
                else
                {
                    animator.SetBool("slash1", false);
                    animator.SetBool("slash1Continuos", false);
                    ataque1 = false;
                    timer1 = 0;
                    timer2 = 0;
                    timer3 = 0;
                    animator.SetBool("slash1End", false);
                }
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
                // .Rotate(0, 0, 0);
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
            if (!animator.GetBool("slash1") && characterController.isGrounded)
            {
                animator.SetBool("slash1", true);
                timer1 = 0.02f;
                ataque1 = true;
            }

            if (!animator.GetBool("slash1Continuos") && timer1 > 0.1f)
            {
                animator.SetBool("slash1Continuos", true);
                timer2 = 0.02f;

            }

            if (!animator.GetBool("slash1End") && timer2 > 0.1f)
            {
                animator.SetBool("slash1End", true);
                animator.SetBool("slash1Continuos", false);
                animator.SetBool("slash1", false);
                timer1 = 1;
                timer2 = 1;
                timer3 = 0.02f;
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("roll", true);
            //animator.GetCurrentAnimatorClipInfoCount();
        }

        if (!Input.anyKey)
        {
            //animator.setIdle true;
        }

    }
}

