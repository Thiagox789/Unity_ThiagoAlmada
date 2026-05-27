using UnityEngine;

public class PelotaFisica : MonoBehaviour
{
    private Vector3 posicionInicial;
    private bool seLanzo = false;
    private Vector3 velocidadActual;

    [Header("Movimiento (Parábola simulada)")]
    public float velocidadHaciaAdelante = 15f;
    public float velocidadHaciaArriba = 6f;
    public float gravedadSimulada = 15f;

    void Start()
    {
        posicionInicial = transform.position;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void Update()
    {
        if (seLanzo)
        {
            velocidadActual.y -= gravedadSimulada * Time.deltaTime;
            
            transform.Translate(velocidadActual * Time.deltaTime, Space.World);
        }
    }

    public void LanzarDesdeBoton()
    {
        Debug.Log("Boton presionado. Entrando a LanzarDesdeBoton...");
        
        if (seLanzo) 
        {
            Debug.Log("La pelota ya estaba en vuelo.");
            return;
        }

        seLanzo = true;
        velocidadActual = new Vector3(0f, velocidadHaciaArriba, velocidadHaciaAdelante);
        
        Debug.Log("seLanzo es true. La pelota deberia moverse.");
        Invoke("ResetearPelota", 3f);
    }

    public void ResetearPelota()
    {
        seLanzo = false;
        transform.position = posicionInicial;
    }
}