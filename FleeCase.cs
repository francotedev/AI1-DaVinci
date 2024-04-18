using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeCase : MonoBehaviour
{
    // Transform del objetivo al que se va a huir
    public Transform target;
    // Velocidad de fuga
    public float fleeSpeed = 5f;
    // Radio de fuga
    public float fleeRadius = 10f;

    private void Update()
    {
        // Si no hay un objetivo, no hacer nada
        if (target == null)
            return;

        // Calcular la distancia entre el enemigo y el objetivo
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Verificar si el objetivo está dentro del radio de fuga
        if (distanceToTarget < fleeRadius)
        {
            // Calcular la dirección para huir del objetivo
            Vector3 fleeDirection = transform.position - target.position;

            // Normalizar la dirección de fuga para obtener un vector unitario
            fleeDirection.Normalize();

            // Calcular la posición de fuga
            Vector3 fleePosition = transform.position + fleeDirection * fleeSpeed * Time.deltaTime;

            // Mover al enemigo hacia la posición de fuga
            transform.position = fleePosition;
        }
    }
}
