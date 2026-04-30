using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ControladorPosta : MonoBehaviour
{
    [SerializeField] List<Transform> objetivos;
    [SerializeField] List<Corredor> corredores;
    [SerializeField] ControladorUI miControladorUI;
    [SerializeField] int cantidadVueltas;
    private int VueltasRealizadas = 0;
    private int CorredorActual = 0;
    private bool carreraInicializada = false;


    public void 
}