using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UIController componenteUI; 
    public SoundController controladorSonido;
    public Slider sliderDificultad;   
    public PelotaFisica pelota; 
    
    public float tiempoDeJuego = 30f;
    public int puntosParaGanar = 3;
    
    private int puntosActuales = 0;
    private bool juegoTerminado = false;
    private bool juegoEmpezado = false; 

    void Start()
    {
        if (sliderDificultad != null)
            ActualizarReglasPorSlider(sliderDificultad.value);
    }

    void Update()
    {
        if (!juegoEmpezado || juegoTerminado) return;

        tiempoDeJuego -= Time.deltaTime;
        componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);

        if (tiempoDeJuego <= 0)
        {
            tiempoDeJuego = 0;
            EvaluarFinDePartida();
        }
    }

    public void ActualizarReglasPorSlider(float valorSlider)
    {
        if (juegoEmpezado) return;
        
        puntosParaGanar = 3 + Mathf.RoundToInt(valorSlider * 5f); 
        componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);
    }

    public float ObtenerDificultad() => sliderDificultad != null ? sliderDificultad.value : 0f;

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
            if (sliderDificultad != null) sliderDificultad.interactable = false;
            if (componenteUI != null && componenteUI.textoBoton != null) 
                componenteUI.textoBoton.text = "Lanzar";
        }
        else if (pelota != null)
        {
            pelota.LanzarDesdeBoton();
        }
    }

    public void RegistrarAcierto()
    {
        if (juegoTerminado) return;
        
        controladorSonido?.ReproducirAcierto();
        puntosActuales++;
        componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);

        if (puntosActuales >= puntosParaGanar)
        {
            componenteUI.CambiarColorMarcador(Color.green);
            EvaluarFinDePartida(); 
        }
    }

    public void RegistrarFallo()
    {
        if (!juegoTerminado) controladorSonido?.ReproducirFallo();
    }

    private void EvaluarFinDePartida()
    {
        if (juegoTerminado) return; 

        juegoTerminado = true;
        bool gano = puntosActuales >= puntosParaGanar;
        
        if (gano) controladorSonido?.ReproducirVictoria();
        else controladorSonido?.ReproducirDerrota();

        componenteUI.MostrarPantallaFinal(gano);
    }
}