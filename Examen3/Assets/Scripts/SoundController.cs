using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource sourceSonidos;

    [Header("Audio Clips")]
    public AudioClip clipAcierto;
    public AudioClip clipFallo;
    public AudioClip clipVictoria;
    public AudioClip clipDerrota;

    public void ReproducirAcierto()
    {
        if (sourceSonidos != null && clipAcierto != null)
            sourceSonidos.PlayOneShot(clipAcierto);
    }

    public void ReproducirFallo()
    {
        if (sourceSonidos != null && clipFallo != null)
            sourceSonidos.PlayOneShot(clipFallo);
    }

    public void ReproducirVictoria()
    {
        if (sourceSonidos != null && clipVictoria != null)
        {
            sourceSonidos.clip = clipVictoria;
            sourceSonidos.Play();
        }
    }

    public void ReproducirDerrota()
    {
        if (sourceSonidos != null && clipDerrota != null)
        {
            sourceSonidos.clip = clipDerrota;
            sourceSonidos.Play();
        }
    }
}
