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
        float dificultad = 0f;
        if (controladorJuego != null)
        {
            dificultad = controladorJuego.ObtenerDificultad();
        }

        float velocidadActual = velocidad + (dificultad * 3f); 
        
        float movimientoMatematico = Mathf.Sin(Time.time * velocidadActual);
        float nuevoX = posicionInicial.x + (movimientoMatematico * amplitud);
        
        transform.position = new Vector3(nuevoX, transform.position.y, transform.position.z);
    }
}