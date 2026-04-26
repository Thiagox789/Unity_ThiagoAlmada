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


    float distance;

    void Start() 
    {
        PosicionInicial = transform.position;
    }

    void Update()
    {
        if (target != null && EstaCorriendo == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            distance = Vector3.Distance(transform.position, target.position);

            Debug.Log("Distancia: " + Mathf.Round(distance));
            
            Contador_Pasos++;
            textoVisual.text = "pasos: " + Contador_Pasos.ToString();

            if (distance < 0.1f)
            {
                EstaCorriendo = false;
                // Importante: aquí faltará avisarle al controlador que el siguiente arranque
            }
        }
    }

    // 2. CORREGIDO: public antes que void
    public void Correr(float velocidadSlider)
    {
        speed = velocidadSlider; // Le pasamos la velocidad del slider
        EstaCorriendo = true;
    }

    // 3. CORREGIDO: public antes que void y lógica de reseteo
    public void VolverInicio()
    {
        Contador_Pasos = 0;
        textoVisual.text = "0"; // .text agregado
        transform.position = PosicionInicial; // Volvemos a la guardada
        EstaCorriendo = false;
    }
}