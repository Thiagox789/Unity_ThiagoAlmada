using System.Collections.Generic;
using UnityEngine;

public class ControladorPosta : MonoBehaviour
{
    [SerializeField] List<Transform> objetivos;
    [SerializeField] List<Corredor> corredores;
    [SerializeField] ControladorUI miControladorUI;
    [SerializeField] int cantidadVueltas;
    private int VueltasRealizadas = 0;
    private int CorredorActual = 0;
    private bool carreraInicializada = false;

    public void PosicionarTodos()
    {
        VueltasRealizadas = 0;
        CorredorActual = 0;
        carreraInicializada = false;

        for (int i = 0; i < corredores.Count; i++)
        {
            corredores[i].PosicionarCorredores();
        }
    }
}