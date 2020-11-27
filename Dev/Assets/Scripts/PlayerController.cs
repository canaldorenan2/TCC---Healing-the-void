using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rigidbodyPlayer;

    Animator animacaoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();

        animacaoPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            animacaoPlayer.SetTrigger("run");
            rigidbodyPlayer.AddForce(0,1,0);
        }
    }
}
