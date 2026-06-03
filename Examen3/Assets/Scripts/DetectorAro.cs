using UnityEngine;

public class DetectorAro : MonoBehaviour
{
    public GameController controladorJuego;
    
    [Header("Movimiento del Aro")]
    public float velocidad = 1f;
    public float amplitud = 6f;
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
}