using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControladorUI : MonoBehaviour
{
    [SerializeField] private ControladorPosta controladorPosta;
    [SerializeField] private TextMeshProUGUI textoFinal;
    [SerializeField] private Slider sliderVelocidad;

    void Start()
    {
        if (textoFinal != null)
        {
            textoFinal.gameObject.SetActive(false);
        }

        if (sliderVelocidad != null)
        {
            sliderVelocidad.minValue = 1f;
            sliderVelocidad.maxValue = 3f;
            sliderVelocidad.onValueChanged.AddListener(SliderChanged);
        }
    }

    public void BotonCorrer()
    {
        if (controladorPosta != null && sliderVelocidad != null)
        {
            controladorPosta.IniciarCarrera(sliderVelocidad.value);
        }
    }

    public void BotonPosicionarse()
    {
        if (controladorPosta != null)
        {
            controladorPosta.PosicionarTodos(); // Nombre corregido
            OcultarFinalizacion();             // Limpiar el texto
        }
    }

    private void SliderChanged(float value)
    {
        if (controladorPosta != null)
        {
            controladorPosta.ActualizarVelocidad(value);
        }
    }

    public void MostrarFinalizacion()
    {
        if (textoFinal != null)
        {
            textoFinal.text = "Carrera Finalizada";
            textoFinal.gameObject.SetActive(true);
        }
    }

    public void OcultarFinalizacion()
    {
        if (textoFinal != null)
        {
            textoFinal.gameObject.SetActive(false);
        }
    }
}
