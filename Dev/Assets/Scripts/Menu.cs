using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    float timer = 0;
    public GameObject logo;

    public GameObject canvas;

    private void Update()
    {
        timer += Time.deltaTime;


        if (timer > 6)
        {
            logo.SetActive(false);
            canvas.SetActive(true);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
