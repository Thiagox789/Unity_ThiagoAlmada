using System.Collections.Generic;
using UnityEngine;

public class ControladorPosta : MonoBehaviour
{
    [SerializeField] List<Transform> objetivos;
    [SerializeField] List<Corredor> corredores;
    [SerializeField] ControladorUI miControladorUI;
    [SerializeField] int cantidadVueltas;
    private int corredorActual = 0;
    private int vueltasRealizadas = 0;
    private float velocidadActual;

    public void ActualizarVelocidad(float velocidad2){
        velocidadActual = velocidad2;
        for (int i=0; i<corredores.Count; i++)
        {
            corredores[i].ActualizarVelocidad(velocidadActual);
        }
    }
    public void PosicionarTodos()
    {
        for(int i=0; i<corredores.Count; i++)
        {
            corredores[i].PosicionarCorredores();
        }
        corredorActual = 0;
        vueltasRealizadas = 0;        
    }
    public void IniciarCarrera(float vel)
    {
        ActualizarVelocidad(vel);
        corredores[corredorActual].Correr();
    }


    public void NotificarLlegada()
    {
       corredorActual++;
       if (corredorActual == corredores.Count)
       {
        vueltasRealizadas++;
        corredorActual = 0;
       }
       if(vueltasRealizadas == cantidadVueltas)
       {
        miControladorUI.MostrarFinalizacion();
       }
       else
       {
        corredores[corredorActual].Correr();
       }
    }
}
