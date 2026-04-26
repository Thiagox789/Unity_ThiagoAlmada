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
    public void IniciarCarrera(float velocidadSlider)
    {
        velocidadCarrera = velocidadSlider;
        contadorVueltas = 0;
        corredorActual = 0;
        corredores [corredorActual].Correr(velocidadCarrera);
    }

    public void Resetear()
    {
        contadorVueltas = 0;
        corredorActual = 0;
        foreach (Corredor corredor in corredores)
        {
            corredor.VolverInicio();
        }
    }

    public void ReportarLlegada()
    {
        corredorActual++; // El corredor que llegó le cede el turno al siguiente

        // Si el índice llega al final de la lista, reiniciamos el ciclo
        if (corredorActual >= corredores.Count)
        {
            corredorActual = 0;
            contadorVueltas++; // Se completó una vuelta de todo el equipo
        }

        // --- RESPONSABILIDAD: Controlar las vueltas y comunicar ---
        if (contadorVueltas < cantidadVueltas)
        {
            // Todavía faltan vueltas, arranca el siguiente
            corredores[corredorActual].Correr(velocidadCarrera);
        }
        else
        {
            // Se cumplieron las vueltas: avisar al controlador UI
            if(miControladorUI != null)
            {
                miControladorUI.MostrarFinalizacion();
            }
        }
    }
}