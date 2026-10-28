using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    [SerializeField] private float velocidade = 2f;
    [SerializeField] private float distanciaMovimento = 3f;
    private Vector3 posicaoInicial;
    private bool indoPraCima = true;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        posicaoInicial = transform.position;
    }

    private void FixedUpdate()
    {
        if (indoPraCima)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, velocidade);
            
            if(transform.position.y >= posicaoInicial.y + distanciaMovimento)
            {
                indoPraCima = false;
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -velocidade);

            if(transform.position.y <= posicaoInicial.y - distanciaMovimento)
            {
                indoPraCima = true;
            }
        }
    }
}
