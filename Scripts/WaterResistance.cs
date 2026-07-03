using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WaterResistance : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Ajustes de Atrito")]
    [SerializeField] private float forwardDrag = 0.5f;
    [SerializeField] private float sideDrag = 4.0f; // Bem maior para evitar o "drift"
    [SerializeField] private float angularDragCustom = 0.8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ApplyHydrodynamics();
    }

    void ApplyHydrodynamics()
    {
        // Separa a velocidade local do barco (frente vs lado)
        Vector3 localVelocity = transform.InverseTransformDirection(rb.linearVelocity);

        // Aplica o arrasto de forma independente para cada eixo
        localVelocity.z *= (1f - forwardDrag * Time.fixedDeltaTime); // Frente/Trás
        localVelocity.x *= (1f - sideDrag * Time.fixedDeltaTime);    // Lados (Garante o controle)

        // Devolve a velocidade modificada para o Rigidbody
        rb.linearVelocity = transform.TransformDirection(localVelocity);

        // Amortece a rotação para o barco não girar infinitamente
        rb.angularVelocity *= (1f - angularDragCustom * Time.fixedDeltaTime);
    }
}
