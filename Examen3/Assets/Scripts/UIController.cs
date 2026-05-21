using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;    
    public TextMeshProUGUI textoPuntaje;   
    public TextMeshProUGUI textoBoton;     
    public GameObject cartelGanaste;       
    public GameObject cartelDerrota;      

    public void MostrarDatosEnPantalla(float tiempo, int puntos, int meta)
    {
        if (textoTiempo != null) 
            textoTiempo.text = "Tiempo Restante: " + Mathf.CeilToInt(tiempo) + "s";
            
        if (textoPuntaje != null) 
            textoPuntaje.text = "Puntaje: " + puntos + "/" + meta;
    }

    public void MostrarPantallaFinal(bool gano)
    {
        if (gano && cartelGanaste != null) cartelGanaste.SetActive(true);
        if (!gano && cartelDerrota != null) cartelDerrota.SetActive(true);

        if (textoBoton != null) textoBoton.text = "¡Reiniciar!";
    }

    public void CambiarColorMarcador(Color colorNuevo)
    {
        if (textoPuntaje != null) textoPuntaje.color = colorNuevo;
    }
}