using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragao : MonoBehaviour
{
    public int vida = 10;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (animator.GetInteger("Life") >= 0)
        {
        }
        else
        {

        }*/
    }
}
