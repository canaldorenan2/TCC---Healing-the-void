using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofreDano : MonoBehaviour
{


    public float CausaDano(int danoAtacante, float vidaAtacado, float resistenciaAtacado)
    {
        float novaVida;
        novaVida = vidaAtacado - (resistenciaAtacado - danoAtacante);

        return novaVida;
    }


}
