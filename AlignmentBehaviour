using UnityEngine;

public class AlignmentBehavior : MonoBehaviour
{
    public LayerMask neighborMask; // Declara una variable pública de tipo LayerMask llamada neighborMask, que se utilizará como máscara para detectar vecinos.
    public float alignmentRadius = 5f; // Declara una variable pública de tipo flotante llamada alignmentRadius e inicializa su valor en 5. Representa el radio de alineación, que define la distancia máxima a la que un agente buscará vecinos para alinearse con ellos.
    public float maxSpeed = 5f; // Declara una variable pública de tipo flotante llamada maxSpeed e inicializa su valor en 5. Representa la velocidad máxima a la que el agente puede moverse.

    void Update() // Define un método Update() que se ejecuta en cada frame.
    {
        Collider[] neighbors = Physics.OverlapSphere(transform.position, alignmentRadius, neighborMask); // Utiliza Physics.OverlapSphere para detectar todos los colisionadores dentro de un radio de alignmentRadius alrededor de la posición actual del agente, aplicando la máscara neighborMask. Almacena los colisionadores detectados en un array de tipo Collider llamado neighbors.
        Vector3 averageDirection = Vector3.zero; // Inicializa un vector averageDirection con valor cero, que se utilizará para calcular la dirección promedio de los vecinos.

        foreach (Collider neighbor in neighbors) // Itera a través de todos los vecinos detectados.
        {
            averageDirection += neighbor.transform.forward; // Agrega la dirección hacia adelante del vecino actual al vector averageDirection.
        }

        if (neighbors.Length > 0) // Comprueba si hay vecinos detectados.
        {
            averageDirection /= neighbors.Length; // Calcula la dirección promedio dividiendo la suma de todas las direcciones de los vecinos por la cantidad de vecinos.
            averageDirection.Normalize(); // Normaliza el vector averageDirection para obtener una dirección unitaria.
            transform.Translate(averageDirection * maxSpeed * Time.deltaTime); // Mueve el agente en la dirección promedio calculada, con una velocidad controlada por el tiempo entre frames (Time.deltaTime), y multiplicada por la velocidad máxima del agente (maxSpeed).
        }
    }
}
