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
        if (juegoEmpezado == false || juegoTerminado == true) return;

        tiempoDeJuego -= Time.deltaTime;
        
        if (componenteUI != null)
        {
            componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);
        }

        if (tiempoDeJuego <= 0)
        {
            tiempoDeJuego = 0;
            EvaluarFinDePartida();
        }
    }

    public void ActualizarReglasPorSlider(float valorSlider)
    {
        if (juegoEmpezado == true) return;
        int nivelDificultad = Mathf.RoundToInt(valorSlider);

        switch(nivelDificultad)
        {
            case 1: puntosParaGanar = 5; break;
            case 2: puntosParaGanar = 7; break;
            case 3: puntosParaGanar = 9; break;
            case 4: puntosParaGanar = 12; break;
            case 5: puntosParaGanar = 15; break;
        }   
        if (componenteUI != null)
        {
            componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);
        }
    }

    public float ObtenerDificultad()
    {
        if (sliderDificultad != null)
        {
            return sliderDificultad.value;
        }
        return 0f;
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
            if (sliderDificultad != null) sliderDificultad.interactable = false; 
            if (componenteUI != null && componenteUI.textoBoton != null) componenteUI.textoBoton.text = "Lanzar";
        }
        else 
        {
            if (pelota != null) pelota.LanzarDesdeBoton();
        }
    }

    public void RegistrarAcierto()
    {
        if (juegoTerminado == true) return;
        
        if (controladorSonido != null) controladorSonido.ReproducirAcierto();
        puntosActuales++;
        
        if (componenteUI != null)
        {
            componenteUI.MostrarDatosEnPantalla(tiempoDeJuego, puntosActuales, puntosParaGanar);
            if (puntosActuales >= puntosParaGanar)
            {
                componenteUI.CambiarColorMarcador(Color.green);
            }
        }
    }

    public void RegistrarFallo()
    {
        if (juegoTerminado == false)
        {
            if (controladorSonido != null) controladorSonido.ReproducirFallo();
        }
    }

    private void EvaluarFinDePartida()
    {
        if (juegoTerminado == true) return; 
        
        juegoTerminado = true;
        
        if (puntosActuales >= puntosParaGanar)
        {
            if (controladorSonido != null) controladorSonido.ReproducirVictoria();
            if (componenteUI != null) componenteUI.MostrarPantallaFinal(true);
        }
        else
        {
            if (controladorSonido != null) controladorSonido.ReproducirDerrota();
            if (componenteUI != null) componenteUI.MostrarPantallaFinal(false);
        }
    }
}