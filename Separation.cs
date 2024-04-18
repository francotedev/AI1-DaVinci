using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : MonoBehaviour
{

    //Recuerden que para que les funcione tienen que setear todo bien. Es decir, tienen que crear un tag de Ground, o el nombre que quieran para que opere de forma correcta !
    // Radio de separación
    public float separationRadius = 2.0f;
    // Fuerza de separación
    public float separationStrength = 5.0f;
    // Tag del suelo
    public string groundTag = "Ground";

    private void Update()
    {
        // Obtener los colliders dentro del radio de separación
        Collider[] colliders = Physics.OverlapSphere(transform.position, separationRadius);
        Vector3 separationVector = Vector3.zero;
        int separationCount = 0;

        // Calcular el vector de separación para cada objeto cercano
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.gameObject.tag != groundTag)
            {
                // Calcular el vector de separación desde el otro objeto
                Vector3 offset = transform.position - collider.transform.position;
                separationVector += offset.normalized / offset.magnitude;
                separationCount++;
            }
        }

        // Si hay objetos cercanos
        if (separationCount > 0)
        {
            // Calcular el vector de separación promedio
            separationVector /= separationCount;

            // Aplicar la fuerza de separación
            Vector3 separationForce = separationVector.normalized * separationStrength * Time.deltaTime;
            transform.position += separationForce;
        }
    }

    // Dibujar el radio de separación en el editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, separationRadius);
    }
}
