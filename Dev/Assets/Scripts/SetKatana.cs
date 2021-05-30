using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetKatana : MonoBehaviour
{
    public Text text;
    //public AudioClip flauta;
    public AudioSource flauta1;
    public ThirdPersonMovement scriptPlayer;
    public Griffo scriptGriffo;

    public Image imagem;

    bool katanaAdquirida;

    // Start is called before the first frame update
    void Start()
    {
        katanaAdquirida = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (katanaAdquirida)
        {
            scriptPlayer.katana.SetActive(true);
            scriptGriffo.katanaColetada = true;
            imagem.gameObject.SetActive(true);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            text.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                flauta1.Play();
                this.gameObject.transform.Translate(0, -10, 0);
                katanaAdquirida = true;
                //this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
    }
}
