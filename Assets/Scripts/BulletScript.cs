using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BulletScript : MonoBehaviour
{

    public float speed = 6; 
    private SpaceshipScript spaceshipScript; //Essa variável acessa o SpaceshipScript

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        rb.velocity = new Vector2(0, speed);

        spaceshipScript = GameObject.Find("spaceship").GetComponent<SpaceshipScript>(); //Essa linha acessa o objeto spaceship
    }


    void OnTriggerEnter2D (Collider2D outro)
    {
        //Destrói o chinelo quando bate no asteroide
        if(outro.gameObject.tag == "asteroidTag")
        {
            Destroy(this.gameObject);

            //acessa a variável vidas da spaceship e faz o valor - 1
            spaceshipScript.vidas += -1; 

            if (spaceshipScript.vidas == 0)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene("menu");
            }
            //TERMINA AQUI
        }

        //Destróis o chinelo quando bate no alvo
        if(outro.gameObject.tag == "targetTag")
        {
            Destroy(this.gameObject);
            //ptScript.pontos ++;
        }
    }

    // Quando o chinelo ficar invisível será destruída 
    void OnBecameInvisible ()
    {
        // Destroi o chinelo quando já está fora da tela 
        Destroy (gameObject);
    }
}
