using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsteroidScript : MonoBehaviour
{
    // Contem a velocidade do obstáculo
    public int speed = -5;
    private PointsScript ptScript; // Para se comunicar com o SpaceshipScript



    // Start is called before the first frame update
    void Start()
    {
        ptScript = GameObject.Find ("Pontuacao").GetComponent<PointsScript> ();
        
        // Adicionar speed à velocidade do obstáculo
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();

        rb.velocity = new Vector2(speed, 0);
                               //(X, Y)   

        // Faz o obstáculo rodar em si mesmo aleatoriamentre entre -200 e 200 graus
        rb.angularVelocity = Random.Range(-200, 200);

        // Destroi o obstáculo após 3s, que ele não está mais visível na tela
        Destroy(gameObject, 3);
   
    }


    void OnTriggerEnter2D (Collider2D outro)
    {
        //Destrói o obstáculo ao colidir com a bala
        if(outro.gameObject.tag == "balaTag")
        {
            Destroy(this.gameObject);
        }
    }
}
