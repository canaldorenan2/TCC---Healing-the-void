using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyJump : MonoBehaviour
{

    private ThirdPersonMovement refScriptThirdPerson;

    void Start()
    {
        refScriptThirdPerson = GameObject.Find("ThirdPersonPlayer").GetComponent<ThirdPersonMovement>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            refScriptThirdPerson.colidindoTerreno = false;
            refScriptThirdPerson.jump = true;
            refScriptThirdPerson.flyJump = true;
            refScriptThirdPerson.animator.SetBool("jump", true);
            refScriptThirdPerson.velocidadeAceleracao = 10;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            refScriptThirdPerson.flyJump = false;
            refScriptThirdPerson.velocidadeAceleracao = -1;
        }
    }
}
