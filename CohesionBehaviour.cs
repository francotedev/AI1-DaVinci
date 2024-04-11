using UnityEngine;

public class CohesionBehavior : MonoBehaviour
{
    public LayerMask neighborMask; // Declara una variable pública de tipo LayerMask llamada neighborMask, que se utilizará como máscara para detectar vecinos.
    public float cohesionRadius = 5f; // Declara una variable pública de tipo flotante llamada cohesionRadius e inicializa su valor en 5. Representa el radio de cohesión, que define la distancia máxima a la que un agente buscará vecinos.
    public float maxSpeed = 5f; // Declara una variable pública de tipo flotante llamada maxSpeed e inicializa su valor en 5. Representa la velocidad máxima a la que el agente puede moverse.

    void Update() // Define un método Update() que se ejecuta en cada frame.
    {
        Collider[] neighbors = Physics.OverlapSphere(transform.position, cohesionRadius, neighborMask); // Utiliza Physics.OverlapSphere para detectar todos los colisionadores dentro de un radio de cohesionRadius alrededor de la posición actual del agente, aplicando la máscara neighborMask. Almacena los colisionadores detectados en un array de tipo Collider llamado neighbors.
        Vector3 averagePosition = Vector3.zero; // Inicializa un vector averagePosition con valor cero, que se utilizará para calcular la posición promedio de los vecinos.

        foreach (Collider neighbor in neighbors) // Itera a través de todos los vecinos detectados.
        {
            averagePosition += neighbor.transform.position; // Agrega la posición del vecino actual al vector averagePosition.
        }

        if (neighbors.Length > 0) // Comprueba si hay vecinos detectados.
        {
            averagePosition /= neighbors.Length; // Calcula la posición promedio dividiendo la suma de todas las posiciones de los vecinos por la cantidad de vecinos.
            Vector3 direction = (averagePosition - transform.position).normalized; // Calcula la dirección hacia la posición promedio de los vecinos desde la posición actual del agente y normaliza el resultado para obtener un vector de dirección unitario.
            transform.Translate(direction * maxSpeed * Time.deltaTime); // Mueve el agente en la dirección calculada, con una velocidad controlada por el tiempo entre frames (Time.deltaTime), y multiplicada por la velocidad máxima del agente (maxSpeed).
        }
    }
}
