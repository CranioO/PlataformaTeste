using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 posicaoCheck;

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            posicaoCheck = transform.position;
        }
    }
}
