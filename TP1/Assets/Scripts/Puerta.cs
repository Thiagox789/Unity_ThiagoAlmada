using UnityEngine;

public class Puerta : MonoBehaviour
{
    private Vector3 posicionInicial;
    public float distanciaApertura = 22f;
    public bool estadoPuerta = false; // Ahora el controlador puede verla    
    void Start()
    {
        posicionInicial = transform.position;
    }

    public void AbrirPuerta()
    {
        if (estadoPuerta == false)
        {
            Vector3 posicionPuertaAbierta = new Vector3(posicionInicial.x + distanciaApertura, posicionInicial.y, posicionInicial.z);
            transform.position = posicionPuertaAbierta;
            estadoPuerta = true;
            Debug.Log("Puerta ABierta");
        }
    }

    public void CerrarPuerta()
    {
        if (estadoPuerta == true)
        {
            transform.position = posicionInicial;
            estadoPuerta = false;
            Debug.Log("puerta Cerrada");
        }
    }
}
