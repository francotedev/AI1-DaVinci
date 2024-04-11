using UnityEngine;

public class ArriveBehavior : MonoBehaviour
{
    public Transform target; // Objeto que representa el objetivo al que se desea llegar
    public float maxSpeed = 5f; // Velocidad máxima a la que puede moverse el agente
    public float slowingDistance = 5f; // Distancia a partir de la cual el agente comenzará a desacelerar

    void Update()
    {
        if (target != null) // Verifica si hay un objetivo asignado
        {
            Vector3 targetDirection = target.position - transform.position; // Calcula la dirección hacia el objetivo
            float distance = targetDirection.magnitude; // Calcula la distancia al objetivo
            float speed = maxSpeed; // Inicializa la velocidad del agente como la velocidad máxima

            if (distance < slowingDistance) // Comprueba si el agente está dentro de la distancia de desaceleración
            {
                speed = maxSpeed * (distance / slowingDistance); // Ajusta la velocidad proporcionalmente a la distancia
            }

            // Mueve el agente hacia el objetivo con la velocidad calculada teniendo en cuenta el tiempo entre frames
            transform.Translate(targetDirection.normalized * speed * Time.deltaTime);
        }
    }
}
