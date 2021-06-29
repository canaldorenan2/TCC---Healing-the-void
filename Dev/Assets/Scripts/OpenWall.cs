using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWall : MonoBehaviour
{
    public Dragao dragon;

    // Update is called once per frame
    void Update()
    {
        if (dragon.vivo == false)
        {
            Destroy(this.gameObject);
        }
    }
}
