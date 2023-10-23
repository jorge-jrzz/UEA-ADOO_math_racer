using UnityEngine;

public class ColisionConJugador : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aquí puedes agregar lógica para lo que sucede cuando el objeto colisiona con el jugador.
            // Puedes destruir el objeto, aumentar puntos, mostrar efectos, etc.
            Destroy(gameObject);
        }
    }
}
