using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UIController componenteUI; 
    public Slider sliderDificultad;   

    public float tiempoDeJuego = 30f;
    public int puntosParaGanar = 3;
    private int puntosActuales = 0;
    private bool juegoTerminado = false;
    private bool juegoEmpezado = false; 

    void Start()
    {
        if (sliderDificultad != null)
        {
            ActualizarReglasPorSlider(sliderDificultad.value);
        }
    }

    void Update()
    {
        if (!juegoEmpezado || juegoTerminado) return;

        if (tiempoDeJuego > 0)
        {
            tiempoDeJuego -= Time.deltaTime;
            componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);

            if (tiempoDeJuego <= 0)
            {
                tiempoDeJuego = 0;
                EvaluarFinDePartida();
            }
        }
    }

    public void ActualizarReglasPorSlider(float valorSlider)
    {
        if (juegoEmpezado) return;

        puntosParaGanar = 3 + Mathf.RoundToInt(valorSlider * 5f); 
        componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);
    }

    public void PresionarBotonPrincipal()
    {
        if (juegoTerminado)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        if (!juegoEmpezado)
        {
            juegoEmpezado = true;
            if (sliderDificultad != null)
            {
                sliderDificultad.interactable = false;
            }
        }

        puntosActuales++;
        componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);

        if (puntosActuales >= puntosParaGanar)
        {
            componenteUI.CambiarColorMarcador(Color.green);
        }
    }

    void EvaluarFinDePartida()
    {
        juegoTerminado = true;
        bool gano = puntosActuales >= puntosParaGanar;
        componenteUI.MostrarPantallaFinal(gano);
    }
}