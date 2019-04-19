using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour {

    public GameObject ballPrefab;
    public InputField[] vo;
    public Vector3 velocidad;
    protected Rigidbody rb;
    protected Vector3 initialPos;
    private LineRenderer lr;
    public Material[] lineMarterial;
    public AudioClip[] sonidos;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        initialPos = transform.position;
	}
	// Update is called once per frame
	void Update () {
        if (rb.position.y < -12)
        {
            rb.transform.position = new Vector3(initialPos.x, initialPos.y, initialPos.z);
            rb.velocity = new Vector3(0, 0, 0);
        }
        try
        {
            velocidad = new Vector3(System.Convert.ToSingle(vo[0].text), 0, System.Convert.ToSingle(vo[1].text));
            RenderizarLinea();
        }
        catch
        {

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            CrearBola();
        }
        //Debug.Log(Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2)));
        float modulo = Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2));
        if (modulo < 1 && velocidad.z != 0)
        {
            MostrarLineas();
        }
        else
        {
            OcultarLineas();
        }
	}
    private void OnBecameInvisible()
    {
        rb.transform.position = initialPos;
    }

    public void Actuar()
    {
        rb.AddForce(velocidad);
    }
    Vector3 lastVelocidad = new Vector3(0, 0, 0);
    public void RenderizarLinea()
    {
        lr.SetPosition(0, rb.position);
        if (lastVelocidad != velocidad)
        {
            lr.SetPosition(1, velocidad);
        }
    }
    public void MostrarLineas()
    {
        lr.material.color = new Color32(255, 255, 0, 255);
    }
    public void OcultarLineas()
    {
        lr.material.color = new Color32(0, 0, 0, 0);
    }
    /// <summary>
    /// Comprueba si se muestran las líneas
    /// Devuelve: TRUE si se muestran y FALSE si no se muestran
    /// </summary>
    /// <returns></returns>
    public bool ComprobarLineas()
    {
        if(lr.material.color.a == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void CrearBola()
    {
        Instantiate(ballPrefab, new Vector3(rb.position.x, rb.position.y + 0.3f, rb.position.z), new Quaternion(0, 0, 0, 0));
    }
    public void ReproducirSonidoColision()
    {
        AudioSource a = GetComponent<AudioSource>();
        float random = Random.Range(-1.2f, 1.2f);
        if(Mathf.Abs(random)> 0.5f)
        {
            a.pitch = random;
        }
        else
        {
            a.pitch = 1;
        }
        a.clip = sonidos[Random.Range(0, sonidos.Length)];
        a.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (velocidad != new Vector3(0, 0, 0))
        {
            ReproducirSonidoColision();
        }
        if(collision.gameObject.name == "Cube")
        {
            rb.transform.position = initialPos;
        }
    }
}
