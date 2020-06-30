using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public AudioClip audioParqueFase1;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(audioParqueFase1, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
