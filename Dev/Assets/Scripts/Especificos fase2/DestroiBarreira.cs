using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiBarreira : MonoBehaviour
{
    public Dragao dragao;

    private void Start()
    {
        dragao = GameObject.Find("Dragon").GetComponent<Dragao>();
    }

    public void Update()
    {
        if (dragao.vivo == false)
        {
            Destroy(this.gameObject);
        }
    }
}
