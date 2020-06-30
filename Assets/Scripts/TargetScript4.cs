using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript4 : MonoBehaviour
{
    private PointsScript ptScript; // Para se comunicar com o scriptNave

    // Start is called before the first frame update
    void Start()
    {
        ptScript = GameObject.Find ("Pontuacao").GetComponent<PointsScript> ();
    }

    void OnTriggerEnter2D (Collider2D outro)
    {
        if(outro.gameObject.tag == "balaTag")
        {
            //Acessa a pontuação
            ptScript.pontos = ptScript.pontos + 4; //Soma + 4 aos pontos
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
