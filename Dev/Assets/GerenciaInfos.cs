using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciaInfos : MonoBehaviour
{
    int fragmentoAgua, fragmentoTerra, fragmentoFogo, fragmentoAr = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GuardaValores()
    {
        fragmentoAgua = ThirdPersonMovement.sagua;
        fragmentoTerra = ThirdPersonMovement.sterra;
        fragmentoFogo = ThirdPersonMovement.sfogo;
        fragmentoAr = ThirdPersonMovement.sar;
    }
}
