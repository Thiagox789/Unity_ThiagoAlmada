using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] private Cubo cubo;

    public void CambiarTamaño(float valor)
    {
        if (cubo != null)
        {
            cubo.tamaño = valor;
        }
    }
}
