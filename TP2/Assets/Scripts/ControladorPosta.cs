using System.Collections.Generic;
using UnityEngine;

public class ControladorPosta : MonoBehaviour
{
    [SerializeField] List<Transform> objetivos;
    [SerializeField] List<Corredor> corredores;
    [SerializeField] ControladorUI miControladorUI;
    [SerializeField] int cantidadVueltas;
    
    private int contadorVueltas = 0;
    private int corredorActual = 0;
    private float velocidadCarrera = 0f;
    private bool carreraIniciada = false;

    public void IniciarCarrera(float velocidadSlider)
    {
        velocidadCarrera = velocidadSlider;
        contadorVueltas = 0;
        corredorActual = 0;
        carreraIniciada = true;

        Debug.Log("CARRERA INICIADA - Objetivo: " + cantidadVueltas + " vueltas.");

        if (miControladorUI != null)
        {
            miControladorUI.OcultarFinalizacion();
        }

        // Resetear todos a sus posiciones antes de empezar
        foreach (Corredor c in corredores)
        {
            c.VolverInicio();
        }

        LanzarSiguienteCorredor();
    }

    public void ActualizarVelocidad(float nuevaVelocidad)
    {
        velocidadCarrera = nuevaVelocidad;
        if (carreraIniciada && corredorActual < corredores.Count)
        {
            corredores[corredorActual].CambiarVelocidad(velocidadCarrera);
        }
    }

    public void ReportarLlegada()
    {
        Debug.Log("Corredor " + corredorActual + " llegó a su meta.");
        corredorActual++;

        // ¿Completaron todos el ciclo? = una vuelta
        if (corredorActual >= corredores.Count)
        {
            corredorActual = 0;
            contadorVueltas++;
            Debug.Log("VUELTA COMPLETADA: " + contadorVueltas + " / " + cantidadVueltas);

            if (contadorVueltas < cantidadVueltas)
            {
                // Faltan vueltas: resetear todos a posición inicial y empezar de nuevo
                Debug.Log("Reseteando posiciones para la siguiente vuelta...");
                foreach (Corredor c in corredores)
                {
                    c.VolverInicio();
                }
            }
        }

        if (contadorVueltas < cantidadVueltas)
        {
            LanzarSiguienteCorredor();
        }
        else
        {
            Debug.Log("CARRERA FINALIZADA. Se cumplieron las " + cantidadVueltas + " vueltas.");
            carreraIniciada = false;
            if (miControladorUI != null)
            {
                miControladorUI.MostrarFinalizacion();
            }
        }
    }

    private void LanzarSiguienteCorredor()
    {
        if (corredorActual < corredores.Count && corredorActual < objetivos.Count)
        {
            Debug.Log("Lanzando corredor " + corredorActual + " hacia objetivo " + corredorActual);
            corredores[corredorActual].Correr(velocidadCarrera, objetivos[corredorActual]);
        }
    }

    public void Resetear()
    {
        carreraIniciada = false;
        contadorVueltas = 0;
        corredorActual = 0;
        foreach (Corredor c in corredores)
        {
            c.VolverInicio();
        }
        
        if (miControladorUI != null)
        {
            miControladorUI.OcultarFinalizacion();
        }
        Debug.Log("Sistema Reseteado.");
    }
}