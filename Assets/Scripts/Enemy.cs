using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad = 1f;
    public float tiempoMovimiento = 0.5f;
    public float tiempoEspera = 1f;

    // Límites del área
    public float minX = -9f;
    public float maxX = 9f;
    public float minY = -5f;
    public float maxY = 5f;

    private Vector2 direccion;
    private bool moviendo;

    void Start()
    {
        StartCoroutine(MovimientoAleatorio());
    }

    IEnumerator MovimientoAleatorio()
    {
        while (true)
        {
            ElegirDireccion();

            moviendo = true;
            yield return new WaitForSeconds(tiempoMovimiento);

            moviendo = false;
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    void Update()
    {
        if (moviendo)
        {
            transform.Translate(direccion * velocidad * Time.deltaTime);

            // Limitar el movimiento dentro del área
            Vector3 posicion = transform.position;

            posicion.x = Mathf.Clamp(posicion.x, minX, maxX);
            posicion.y = Mathf.Clamp(posicion.y, minY, maxY);

            transform.position = posicion;
        }
    }

    void ElegirDireccion()
    {
        int numero = Random.Range(0, 4);

        switch (numero)
        {
            case 0:
                direccion = Vector2.up;
                break;
            case 1:
                direccion = Vector2.down;
                break;
            case 2:
                direccion = Vector2.left;
                break;
            case 3:
                direccion = Vector2.right;
                break;
        }
    }
}