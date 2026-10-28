using UnityEngine;

public class InimigoPerseguidor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField]private float velocidadePerseguicao = 2f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       float direcao = Mathf.Sign(player.position.x - transform.position.x);
        rb.linearVelocity = new Vector2(direcao * velocidadePerseguicao, rb.linearVelocity.y);
    }
}
