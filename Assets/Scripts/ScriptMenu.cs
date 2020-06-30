using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    public AudioClip audioParque;

    void Start()
    {
        AudioSource.PlayClipAtPoint(audioParque, transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        // Teclando ESC saira do Jogo, mas somente no executavel e nao dentro do editor
        if (Input.GetKey ("escape")) 
        {
         Application.Quit();
        }   
    }

    //Inicia o jogo ao clicar no botão
    public void OnClickStartGame()
    {
        SceneManager.LoadScene("fase1");
    }

    //Sai do jogo ao clicar no botão
    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
