using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource sourceMusica;
    public AudioSource sourceEfectos; 

    public AudioClip clipAcierto;
    public AudioClip clipFallo;
    public AudioClip clipVictoria;
    public AudioClip clipDerrota;
    
    public DatosVolumen datosVolumen;

    void Start()
    {
        ActualizarVolumen();
    }

    public void ActualizarVolumen()
    {
        if (datosVolumen != null)
        {
            if (sourceMusica != null) sourceMusica.volume = datosVolumen.volumen;
            if (sourceEfectos != null) sourceEfectos.volume = datosVolumen.volumen;
        }
    }

    public void ReproducirAcierto()
    {
        ActualizarVolumen();
        if (sourceEfectos != null && clipAcierto != null)
        {
            sourceEfectos.PlayOneShot(clipAcierto);
        }
    }

    public void ReproducirFallo()
    {
        ActualizarVolumen();
        if (sourceEfectos != null && clipFallo != null)
        {
            sourceEfectos.PlayOneShot(clipFallo);
        }
    }

    public void ReproducirVictoria()
    {
        ActualizarVolumen();
        if (sourceMusica != null && clipVictoria != null)
        {
            sourceMusica.clip = clipVictoria;
            sourceMusica.Play();
        }
    }

    public void ReproducirDerrota()
    {
        ActualizarVolumen();
        if (sourceMusica != null && clipDerrota != null)
        {
            sourceMusica.clip = clipDerrota;
            sourceMusica.Play();
        }
    }
}
