using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{

    public StatusBase atacante;
    public StatusBase atacado;

    void CausaDano(StatusBase _atacante, StatusBase _atacado)
    {
        atacante = _atacante;
        atacado = _atacado;

        atacado.Vida = atacado.Vida - atacante.ValorDano;
    }
}
