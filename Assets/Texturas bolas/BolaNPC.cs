using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaNPC : MonoBehaviour
{
    public Material[] randomMat;
    public AudioClip[] audios;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = randomMat[Random.Range(0,randomMat.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameInvisible(){
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource a = GetComponent<AudioSource>();
        float random = Random.Range(-1.2f, 1.2f);
        if (Mathf.Abs(random) > 0.5f)
        {
            a.pitch = random;
        }
        else
        {
            a.pitch = 1;
        }
        a.clip = audios[UnityEngine.Random.Range(0, audios.Length)];
        a.Play();
        /*if(collision.gameObject.name == "Cube")
        {
            Destroy(gameObject);
        }*/
    }
}
