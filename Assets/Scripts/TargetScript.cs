using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Esse script adiciona pontos ao acertar o alvo atrelado a esse script

public class TargetScript : MonoBehaviour
{
    // Start is called before the first frame update

    private PointsScript ptScript; // Para se comunicar com o scriptNave

    void Start()
    {
        //Acessa a pontuação
        ptScript = GameObject.Find ("Pontuacao").GetComponent<PointsScript> ();

    }

    void OnTriggerEnter2D (Collider2D outro)
    {
        if(outro.gameObject.tag == "balaTag")
        {
            ptScript.pontos ++;
        }
    }
}