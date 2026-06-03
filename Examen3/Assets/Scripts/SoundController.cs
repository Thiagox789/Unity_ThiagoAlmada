using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource sourceEfectos;
    public AudioSource sourceMusica;

    [Header("Audio Clips")]
    public AudioClip clipAcierto;
    public AudioClip clipFallo;
    public AudioClip clipVictoria;
    public AudioClip clipDerrota;

    public void ReproducirAcierto()
    {
        if (sourceEfectos != null && clipAcierto != null)
            sourceEfectos.PlayOneShot(clipAcierto);
    }

    public void ReproducirFallo()
    {
        if (sourceEfectos != null && clipFallo != null)
            sourceEfectos.PlayOneShot(clipFallo);
    }

    public void ReproducirVictoria()
    {
        if (sourceMusica != null && clipVictoria != null)
        {
            sourceMusica.clip = clipVictoria;
            sourceMusica.Play();
        }
    }

    public void ReproducirDerrota()
    {
        if (sourceMusica != null && clipDerrota != null)
        {
            sourceMusica.clip = clipDerrota;
            sourceMusica.Play();
        }
    }
}
