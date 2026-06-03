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
        float dificultad = 1f;
        if (controladorJuego != null)
        {
            dificultad = controladorJuego.ObtenerDificultad();
        }

        int nivel = Mathf.RoundToInt(dificultad);
        float velocidadActual = velocidad;
        switch (nivel)
        {
            case 1: velocidadActual = 1.2f; break;
            case 2: velocidadActual = 1.3f; break;
            case 3: velocidadActual = 1.4f; break;
            case 4: velocidadActual = 1.6f; break;
            case 5: velocidadActual = 1.8f; break;
        }       
        float movimientoMatematico = Mathf.Sin(Time.time * velocidadActual);
        float nuevoX = posicionInicial.x + (movimientoMatematico * amplitud);
        
        transform.position = new Vector3(nuevoX, transform.position.y, transform.position.z);
    }
}