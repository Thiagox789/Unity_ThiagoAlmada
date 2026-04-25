using UnityEngine;

public class ControladorPuerta : MonoBehaviour
{
    public Puerta Puerta;
    public void LlamarAbrirPuerta() 
    {
        Puerta.AbrirPuerta();
    }

    public void LlamarCerrarPuerta()
    {
        Puerta.CerrarPuerta();
    }
}
