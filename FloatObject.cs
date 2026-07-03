using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatObject : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Configurações d'Água")]
    [SerializeField] private float waterLevel = 0f; // A altura (Y) onde está a sua água
    [SerializeField] private float bounceForce = 15f; // Força do impulso para cima
    [SerializeField] private float waterDrag = 2f; // Arrasto na água (evita o efeito mola)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Verifica se a base do barco passou para baixo do nível da água
        if (transform.position.y < waterLevel)
        {
            // Calcula o quanto o barco afundou
            float displacement = Mathf.Clamp01((waterLevel - transform.position.y) / 1f);
            
            // Aplica a força para cima com base no quanto ele afundou (simula o empuxo)
            Vector3 buoyancyForce = Vector3.up * displacement * bounceForce;
            rb.AddForce(buoyancyForce, ForceMode.Acceleration);

            // Amortece a velocidade para o barco não ficar quicando infinitamente
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * (1f - waterDrag * Time.fixedDeltaTime), rb.linearVelocity.z);
        }
    }
}