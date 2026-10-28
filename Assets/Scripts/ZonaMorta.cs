using UnityEngine;

public class ZonaMorta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            PlayerVida vidaDoPlayer = outro.GetComponent<PlayerVida>();
            vidaDoPlayer.TomarDano(10);
        }
    }
}
