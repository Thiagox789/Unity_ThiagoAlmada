using UnityEngine;

public class DetectorAro : MonoBehaviour
{
    public GameController controladorJuego;
    
    [Header("Movimiento del Aro")]
    public float velocidad = 2f;
    public float amplitud = 3f;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float dificultad = controladorJuego != null ? controladorJuego.ObtenerDificultad() : 0f;
        float velocidadActual = velocidad + (dificultad * 5f); 
        
        float nuevoX = posicionInicial.x + Mathf.Sin(Time.time * velocidadActual) * amplitud;
        transform.position = new Vector3(nuevoX, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto entró al aro: " + other.gameObject.name + " con tag: " + other.tag);
        
        if (other.GetComponent<PelotaFisica>() != null || other.CompareTag("Player") || other.CompareTag("Sphere"))
        {
            Debug.Log("¡Era la pelota! Sumando punto...");
            controladorJuego.SumarPuntoReal();
        }
    }
}