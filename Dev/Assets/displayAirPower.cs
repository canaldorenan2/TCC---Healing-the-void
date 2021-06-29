using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayAirPower : MonoBehaviour
{
    public void displayTxt()
    {
        gameObject.SetActive(true);
        Destroy(this.gameObject, 4);
    }
}
