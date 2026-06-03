using UnityEngine;

public class PelotaFisica : MonoBehaviour
{
    public GameController gameController;
    private Vector3 posicionInicial;
    private bool seLanzo = false;
    private bool yaEvaluado = false;
    private Vector3 velocidadActual;

    [Header("Movimiento (Parábola simulada)")]
    public float velocidadHaciaAdelante = 4f;
    public float velocidadHaciaArriba = 13f;
    public float gravedadSimulada = 10f;

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
        if (seLanzo) return;

        seLanzo = true;
        yaEvaluado = false;
        velocidadActual = new Vector3(0f, velocidadHaciaArriba, velocidadHaciaAdelante);
        
        Invoke("NotificarFallo", 2f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (yaEvaluado || !seLanzo) return;

        if (other.GetComponent<DetectorAro>() != null || other.CompareTag("Aro"))
        {
            yaEvaluado = true;
            CancelInvoke("NotificarFallo");
            if (gameController != null) gameController.RegistrarAcierto();
            Invoke("ResetearPelota", 0.5f); 
        }
    }

    private void NotificarFallo()
    {
        if (yaEvaluado || !seLanzo) return;

        yaEvaluado = true;
        if (gameController != null) gameController.RegistrarFallo();
        ResetearPelota();
    }

    public void ResetearPelota()
    {
        seLanzo = false;
        yaEvaluado = false;
        transform.position = posicionInicial;
        velocidadActual = Vector3.zero;
    }
}