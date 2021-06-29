using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximaFase : MonoBehaviour
{

    int fragmentoAgua, fragmentoTerra, fragmentoFogo, fragmentoAr = 0;
    int cont = 0;

    void GuardaValores()
    {
        fragmentoAgua = ThirdPersonMovement.sagua;
        fragmentoTerra = ThirdPersonMovement.sterra;
        fragmentoFogo = ThirdPersonMovement.sfogo;
        fragmentoAr = ThirdPersonMovement.sar;
    }

    void CarregaValores()
    {
        ThirdPersonMovement.sagua = fragmentoAgua;
        ThirdPersonMovement.sterra = fragmentoTerra;
        ThirdPersonMovement.sfogo = fragmentoFogo;
        ThirdPersonMovement.sar = fragmentoAr;
    }


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            if (cont == 0)
            {
                CarregaValores();
                cont = 1;
                //Destroy(this.gameObject);
            }

        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && SceneManager.GetActiveScene().name == "Level 1")
        {
            GuardaValores();
            DontDestroyOnLoad(this.gameObject);
            SceneManager.LoadScene("Level 2");
        }
    }
}
