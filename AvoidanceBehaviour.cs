using UnityEngine;

public class AvoidanceBehavior : MonoBehaviour
{
    public LayerMask obstacleMask; // Declara una variable pública de tipo LayerMask llamada obstacleMask, que se utilizará como máscara para detectar obstáculos.
    public float avoidanceRadius = 2f; // Declara una variable pública de tipo flotante llamada avoidanceRadius e inicializa su valor en 2. Representa el radio de evitación, que define la distancia máxima a la que un agente buscará obstáculos para evitarlos.
    public float maxSpeed = 5f; // Declara una variable pública de tipo flotante llamada maxSpeed e inicializa su valor en 5. Representa la velocidad máxima a la que el agente puede moverse.

    void Update() // Define un método Update() que se ejecuta en cada frame.
    {
        Collider[] obstacles = Physics.OverlapSphere(transform.position, avoidanceRadius, obstacleMask); // Utiliza Physics.OverlapSphere para detectar todos los colisionadores dentro de un radio de avoidanceRadius alrededor de la posición actual del agente, aplicando la máscara obstacleMask. Almacena los colisionadores detectados en un array de tipo Collider llamado obstacles.
        Vector3 avoidanceVector = Vector3.zero; // Inicializa un vector avoidanceVector con valor cero, que se utilizará para calcular el vector de evitación.

        foreach (Collider obstacle in obstacles) // Itera a través de todos los obstáculos detectados.
        {
            avoidanceVector += (transform.position - obstacle.transform.position); // Agrega el vector apuntando desde la posición del obstáculo hacia la posición del agente al vector avoidanceVector. Esto representa la dirección en la que el agente debe moverse para evitar el obstáculo.
        }

        if (obstacles.Length > 0) // Comprueba si hay obstáculos detectados.
        {
            avoidanceVector /= obstacles.Length; // Calcula el vector de evitación promedio dividiendo la suma de todos los vectores de evitación por la cantidad de obstáculos.
            avoidanceVector.Normalize(); // Normaliza el vector avoidanceVector para obtener una dirección unitaria.
            transform.Translate(avoidanceVector * maxSpeed * Time.deltaTime); // Mueve el agente en la dirección de evitación calculada, con una velocidad controlada por el tiempo entre frames (Time.deltaTime), y multiplicada por la velocidad máxima del agente (maxSpeed).
        }
    }
}
