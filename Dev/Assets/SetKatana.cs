using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetKatana : MonoBehaviour
{
    public Text text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            text.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                
                Destroy(this.gameObject);
            }
        }
    }
}
