using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofreDano : MonoBehaviour
{


    public int CausaDano(int danoAtacante, int vidaAtacado, int resistenciaAtacado)
    {
        int novaVida;
        novaVida = vidaAtacado - (resistenciaAtacado - danoAtacante);

        return novaVida;
    }


}
