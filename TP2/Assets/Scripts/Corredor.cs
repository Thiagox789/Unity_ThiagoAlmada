using UnityEngine;
using TMPro;

public class Corredor : MonoBehaviour
{
    [SerializeField] Transform target; 
    [SerializeField] float speed;

    [Header("UI del Corredor")]
    [SerializeField] TextMeshProUGUI textoVisual;

    private int Contador_Pasos = 0;
    private bool EstaCorriendo = false;
    private Vector3 PosicionInicial;
    [SerializeField] private ControladorPosta miControlador;

    float distance;

    void Start() 
    {
        PosicionInicial = transform.position;
    }

    void Update()
    {
        if (target != null && EstaCorriendo)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            distance = Vector3.Distance(transform.position, target.position);
            
            Contador_Pasos++;
            if (textoVisual != null)
            {
                // Solo el número para maximizar espacio
                textoVisual.text = Contador_Pasos.ToString();
            }

            if (distance < 0.1f)
            {
                EstaCorriendo = false;
                if (miControlador != null)
                {
                    miControlador.ReportarLlegada();
                }
            }
        }
    }

    public void Correr(float velocidadSlider, Transform nuevoTarget)
    {
        speed = velocidadSlider;
        target = nuevoTarget; 
        EstaCorriendo = true;
    }

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        speed = nuevaVelocidad;
    }

    public void VolverInicio()
    {
        Contador_Pasos = 0;
        if (textoVisual != null)
        {
            textoVisual.text = "0";
        }
        transform.position = PosicionInicial;
        EstaCorriendo = false;
    }
}