using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        //other.transform.Translate(-37, 192, 40);

        Vector3 position = new Vector3(-37, 192, 40);
        other.transform.SetPositionAndRotation(position, Quaternion.identity);
    }
}
