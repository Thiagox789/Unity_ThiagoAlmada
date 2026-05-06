using UnityEngine;

public class Cubo : MonoBehaviour
{
    public float tamaño = 1f;

    void Start()
    {
    }

    void Update()
    {
        transform.localScale = new Vector3(tamaño, tamaño, tamaño);
    }
}
