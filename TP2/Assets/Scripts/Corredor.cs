using System;
using UnityEngine;
using TMPro;
public class Corredor : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] ControladorPosta controladorposta;
    [SerializeField] TextMeshProUGUI Contador_Pasos_Texto;
    [SerializeField] float speed;

    float distance;
    private int Contador_Pasos = 0;
    private int velocidad_Carrera = 0;
    private bool EstoyCorriendo = false;
    private Vector3 posicionInicial;
    private float reloj = 0f;
    void Start()
    {
        posicionInicial = transform.position;
    }
    public void PosicionarCorredores()
    {
        transform.position = posicionInicial;
        Contador_Pasos = 0;
        Contador_Pasos_Texto.text = "0";
        EstoyCorriendo = false;

    }
    public void Correr()
    {
        EstoyCorriendo = true;
    }
    public void ActualizarVelocidad(float velocidad)
    {
        speed = velocidad;
    }


    void Update()
    {
        if (target !=null && EstoyCorriendo== true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            distance = Vector3.Distance(transform.position, target.position);
            reloj+= Time.deltaTime;
            if( reloj >= 0.5f)
            {
                Contador_Pasos++;
                Contador_Pasos_Texto.text = Contador_Pasos.ToString();
                reloj = 0f;
            }

            if ( distance < 0.1f)
            {
                EstoyCorriendo = false;
            }
        }

    }
}