using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatController : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private InputHandler inputHandler;
    private Rigidbody rb;

    [Header("Configurações de Movimento")]
    [SerializeField] private float forwardForce = 1500f;
    [SerializeField] private float turnTorque = 500f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Garante que a física ignore gravidade exagerada se estiver na água, 
        // ou configure os arrastos (drag) iniciais.
        rb.useGravity = true;
    }

   void FixedUpdate()
{
    if (inputHandler == null) return;

    // LINHA DE TESTE: Mostra no Console se o Unity está a ler as teclas
    Debug.Log($"Throttle: {inputHandler.Throttle} | Steer: {inputHandler.Steer}");

    MoveBoat();
    TurnBoat();
}

   void MoveBoat()
{
    // Remove o Time.fixedDeltaTime daqui, o Unity já calcula isso no ForceMode.Force
    Vector3 forwardMovement = transform.forward * inputHandler.Throttle * forwardForce;
    rb.AddForce(forwardMovement, ForceMode.Force);
}

void TurnBoat()
{
    // Remove o Time.fixedDeltaTime daqui também
    Vector3 rotationTorque = transform.up * inputHandler.Steer * turnTorque;
    rb.AddTorque(rotationTorque, ForceMode.Force);
}
    
}