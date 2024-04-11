using UnityEngine;

public class WanderBehavior : MonoBehaviour
{
    public float wanderRadius = 5f; // Declara una variable pública de tipo flotante llamada wanderRadius y la inicializa en 5. Representa el radio en el que el agente puede vagar.
    public float wanderDistance = 10f; // Declara una variable pública de tipo flotante llamada wanderDistance y la inicializa en 10. Representa la distancia a la que el agente puede vagar.
    public float wanderJitter = 1f; // Declara una variable pública de tipo flotante llamada wanderJitter y la inicializa en 1. Representa la variabilidad o aleatoriedad del movimiento.

    void Update() // Define un método Update(), que se ejecuta en cada frame.
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderJitter; // Genera una dirección aleatoria dentro de una esfera unitaria multiplicada por la variable wanderJitter.
        randomDirection.y = 0; // Establece la componente y de la dirección aleatoria en 0 para mantener el movimiento en el plano XZ.

        Vector3 targetPosition = transform.position + transform.forward * wanderDistance + randomDirection * wanderRadius; // Calcula la posición del objetivo hacia donde el agente se dirigirá.

        transform.LookAt(targetPosition); // Hace que el agente mire hacia la posición del objetivo calculada.

        transform.Translate(Vector3.forward * Time.deltaTime * 5f); // Mueve el agente hacia adelante con una velocidad constante multiplicada por el tiempo entre frames. Esto permite que el agente se mueva hacia el objetivo.
    }
}
