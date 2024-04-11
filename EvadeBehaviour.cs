using UnityEngine;

public class EvadeBehavior : MonoBehaviour
{
    public Transform target; // Declara una variable pública de tipo Transform llamada target, que representa el objetivo que el agente debe evitar.
    public float maxSpeed = 5f; // Declara una variable pública de tipo flotante llamada maxSpeed e inicializa su valor en 5. Representa la velocidad máxima a la que el agente puede moverse.

    void Update() // Define un método Update() que se ejecuta en cada frame.
    {
        if (target != null) // Comprueba si el objetivo no es nulo.
        {
            Vector3 targetDirection = target.position - transform.position; // Calcula la dirección hacia el objetivo restando la posición del objetivo de la posición del agente.
            float lookAhead = targetDirection.magnitude / maxSpeed; // Calcula la anticipación (lookAhead) basada en la distancia al objetivo y la velocidad máxima del agente.
            Vector3 targetPosition = target.position + target.GetComponent<Rigidbody>().velocity * lookAhead; // Calcula la posición futura del objetivo teniendo en cuenta su velocidad actual.
            Vector3 desiredVelocity = (transform.position - targetPosition).normalized * maxSpeed; // Calcula la velocidad deseada del agente para evadir el objetivo.
            transform.Translate(desiredVelocity * Time.deltaTime); // Mueve el agente hacia la posición deseada con una velocidad controlada por el tiempo entre frames (Time.deltaTime).
        }
    }
}
