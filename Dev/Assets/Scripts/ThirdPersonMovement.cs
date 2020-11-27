using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController characterController;

    public float speed = 6;

    float horizontal, vertical, targetAngle;

    public Transform camera;

    Vector3 moveDirection;

    Vector3 direction;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, 0f, vertical).normalized;

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
    }

    void ControleAnimacao()
    {
        if (direction.magnitude > 0.1f)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }
}
