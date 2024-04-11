using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; // Objetivo a seguir
    public LayerMask obstacleMask; // Máscara de obstáculos
    public float avoidanceRadius = 2f; // Radio de evitación
    public float separationRadius = 2f; // Radio de separación
    public float cohesionRadius = 5f; // Radio de cohesión
    public float alignmentRadius = 5f; // Radio de alineación
    public float maxSpeed = 5f; // Velocidad máxima
    public float slowingDistance = 5f; // Distancia de desaceleración para Arrive

    private Rigidbody rb; // Rigidbody del enemigo

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody al inicio
    }

    void Update()
    {
        // Cálculo de los comportamientos de Steering
        Vector3 avoidance = Avoidance(); // Comportamiento de evitación de obstáculos
        Vector3 separation = Separation(); // Comportamiento de separación de vecinos
        Vector3 cohesion = Cohesion(); // Comportamiento de cohesión con vecinos
        Vector3 alignment = Alignment(); // Comportamiento de alineación con vecinos
        Vector3 arrive = Arrive(); // Comportamiento de llegar al objetivo

        // Combinación de los comportamientos de Steering
        Vector3 steeringForce = avoidance + separation + cohesion + alignment + arrive;

        // Aplicación de la fuerza resultante al Rigidbody del enemigo
        rb.AddForce(steeringForce);
    }

    // Comportamiento de evitación de obstáculos
    Vector3 Avoidance()
    {
        Collider[] obstacles = Physics.OverlapSphere(transform.position, avoidanceRadius, obstacleMask);
        Vector3 avoidanceVector = Vector3.zero;

        foreach (Collider obstacle in obstacles)
        {
            avoidanceVector += (transform.position - obstacle.transform.position);
        }

        if (obstacles.Length > 0)
        {
            avoidanceVector /= obstacles.Length;
            avoidanceVector.Normalize();
        }

        return avoidanceVector;
    }

    // Comportamiento de separación de vecinos
    Vector3 Separation()
    {
        Collider[] neighbors = Physics.OverlapSphere(transform.position, separationRadius, obstacleMask);
        Vector3 separationVector = Vector3.zero;

        foreach (Collider neighbor in neighbors)
        {
            separationVector += (transform.position - neighbor.transform.position);
        }

        if (neighbors.Length > 0)
        {
            separationVector /= neighbors.Length;
            separationVector.Normalize();
        }

        return separationVector;
    }

    // Comportamiento de cohesión con vecinos
    Vector3 Cohesion()
    {
        Collider[] neighbors = Physics.OverlapSphere(transform.position, cohesionRadius);
        Vector3 averagePosition = Vector3.zero;

        foreach (Collider neighbor in neighbors)
        {
            averagePosition += neighbor.transform.position;
        }

        if (neighbors.Length > 0)
        {
            averagePosition /= neighbors.Length;
            Vector3 direction = (averagePosition - transform.position).normalized;
            return direction;
        }

        return Vector3.zero;
    }

    // Comportamiento de alineación con vecinos
    Vector3 Alignment()
    {
        Collider[] neighbors = Physics.OverlapSphere(transform.position, alignmentRadius);
        Vector3 averageDirection = Vector3.zero;

        foreach (Collider neighbor in neighbors)
        {
            averageDirection += neighbor.transform.forward;
        }

        if (neighbors.Length > 0)
        {
            averageDirection /= neighbors.Length;
            averageDirection.Normalize();
        }

        return averageDirection;
    }

    // Comportamiento de llegar al objetivo
    Vector3 Arrive()
    {
        if (player != null)
        {
            Vector3 targetDirection = player.position - transform.position;
            float distance = targetDirection.magnitude;
            float speed = maxSpeed;

            if (distance < slowingDistance)
            {
                speed = maxSpeed * (distance / slowingDistance);
            }

            Vector3 desiredVelocity = targetDirection.normalized * speed;
            return desiredVelocity - rb.velocity;
        }

        return Vector3.zero;
    }
}
