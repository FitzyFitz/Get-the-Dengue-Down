using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceshipScript : MonoBehaviour
{
    public int speed = 10;
    public GameObject bala;
    public int vidas = 3;
    public Text vidasUI;
    public AudioClip audioNaveColisao;
    
    void Update() 
    {
        Move();

        SpawnBullet();

        PreventLeavingScreen();

        vidasUI.text = "Vidas: " + vidas;

    }

    void Move()
    {
        // Move a velhinha horizontalmente com setas ou com as teclas A e D
        
        // Eixo X – na horizontal
        float horizontal = Input.GetAxis("Horizontal") * speed *                             
        Time.deltaTime;


        float vertical = Input.GetAxis("Vertical") * speed *
        Time.deltaTime;

        transform.Translate(horizontal, vertical, 0, 0);// Aplicando as mudanças
    }


    void SpawnBullet()
    {
        // Quando a barra de espaços é pressionada ela joga o chinelo
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //spawnar a bala
            Instantiate (bala, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        }
    }


    void PreventLeavingScreen()
    {
        //Restringir o movimento entre dois valores 
        if (transform.position.x > 5.6f || transform.position.x < -5.6)
        {
            // Criando o limite 
            float posX = Mathf.Clamp(transform.position.x, -5.6f,5.6f);
            
            // Limitando 
            transform.position = new Vector3(posX,transform.position.y, transform.position.z);
        }

        if (transform.position.y > 4.5f || transform.position.y < -4.5f)
        {
            float posY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);

            transform.position = new Vector2(transform.position.x, posY);
        }
    }

    void OnTriggerEnter2D (Collider2D outro)
    {
        if(outro.gameObject.tag == "asteroidTag")
        {
            Destroy(outro.gameObject);
            // Cada colisao perde uma vida
            vidas = vidas - 1; 

            AudioSource.PlayClipAtPoint(audioNaveColisao, transform.position);
        
            if(vidas==0)
            {
                vidasUI.text = "Vidas: " + vidas;
                SceneManager.LoadScene("menu");
                // Quando topar 3 vezes com o obstáculo, volta para o menu
                Destroy(this.gameObject);
                SceneManager.LoadScene("menu");
            }
        }
    }
    
}
