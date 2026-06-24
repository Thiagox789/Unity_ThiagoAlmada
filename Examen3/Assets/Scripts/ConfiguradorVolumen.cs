using UnityEngine;
using UnityEngine.UI;

public class ConfiguradorVolumen : MonoBehaviour
{
    public Slider sliderVolumen;
    public DatosVolumen datosVolumen;
    public SoundController soundController;

    void Start()
    {
        if (datosVolumen != null && sliderVolumen != null)
        {
            sliderVolumen.value = datosVolumen.volumen;

            sliderVolumen.onValueChanged.AddListener(CambiarVolumen);
        }

        if (sliderVolumen != null)
        {
            CambiarVolumen(sliderVolumen.value);
        }
    }

    public void CambiarVolumen(float valorNuevo)
    {
        if (datosVolumen != null)
        {
            datosVolumen.volumen = valorNuevo;
        }

        if (soundController != null)
        {
            soundController.ActualizarVolumen();
        }
    }
}
