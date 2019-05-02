using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitParticles : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer != 0)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 3)
        {
            ps.Stop();
            timer = 0;
        }
    }
    float timer = 0;
    private void OnCollisionEnter(Collision collision)
    {
        ps.Play();
        timer = 0.1f;
        if(collision.gameObject.tag == "BolaNoInteractiva")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name == "Sphere")
        {
            Bola b = collision.gameObject.GetComponent<Bola>();
            b.rb.position = b.initialPos;
            b.ReproducirSonidoColision();
        }
    }
}
