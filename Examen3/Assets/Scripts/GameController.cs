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
        {
            ActualizarReglasPorSlider(sliderDificultad.value);
        }
    }

    void Update()
    {
        if (juegoEmpezado == false) return;
        if (juegoTerminado == true) return;

        tiempoDeJuego = tiempoDeJuego - Time.deltaTime;
        
        componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);

        if (tiempoDeJuego <= 0)
        {
            tiempoDeJuego = 0;
            EvaluarFinDePartida();
        }
    }

    public void ActualizarReglasPorSlider(float valorSlider)
    {
        if (juegoEmpezado == true) return;
        
        puntosParaGanar = 5 + Mathf.RoundToInt(valorSlider * 5f); 
        componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);
    }

    public float ObtenerDificultad()
    {
        if (sliderDificultad != null)
        {
            return sliderDificultad.value;
        }
        else
        {
            return 0f;
        }
    }

    public void PresionarBotonPrincipal()
    {
        if (juegoTerminado == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        if (juegoEmpezado == false)
        {
            juegoEmpezado = true;
            
            if (sliderDificultad != null)
            {
                sliderDificultad.interactable = false; 
            }
            
            if (componenteUI != null && componenteUI.textoBoton != null)
            {
                componenteUI.textoBoton.text = "Lanzar";
            }
        }
        else 
        {
            if (pelota != null)
            {
                pelota.LanzarDesdeBoton();
            }
        }
    }

    public void RegistrarAcierto()
    {
        if (juegoTerminado == true) return;
        
        if (controladorSonido != null)
        {
            controladorSonido.ReproducirAcierto();
        }

        puntosActuales = puntosActuales + 1;
        componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);

        if (puntosActuales >= puntosParaGanar)
        {
            componenteUI.CambiarColorMarcador(Color.green);
        }
    }

    public void RegistrarFallo()
    {
        if (juegoTerminado == false)
        {
            if (controladorSonido != null)
            {
                controladorSonido.ReproducirFallo();
            }
        }
    }

    private void EvaluarFinDePartida()
    {
        if (juegoTerminado == true) return; 

        juegoTerminado = true;
        
        if (puntosActuales >= puntosParaGanar)
        {
            if (controladorSonido != null)
            {
                controladorSonido.ReproducirVictoria();
            }
            componenteUI.MostrarPantallaFinal(true);
        }
        else
        {
            if (controladorSonido != null)
            {
                controladorSonido.ReproducirDerrota();
            }
            componenteUI.MostrarPantallaFinal(false);
        }
    }
}