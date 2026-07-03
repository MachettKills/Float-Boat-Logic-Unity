using UnityEngine;

public class InputHandler : MonoBehaviour
{
    // Propriedades automáticas (apenas leitura externa)
    public float Throttle { get; private set; }
    public float Steer { get; private set; }

    void Update()
    {
        // Captura WASD / Setas / Controle
        Throttle = Input.GetAxis("Vertical"); // W/S ou Cima/Baixo (-1 a 1)
        Steer = Input.GetAxis("Horizontal");  // A/D ou Esquerda/Direita (-1 a 1)
    }
}
