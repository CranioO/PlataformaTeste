using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private float velocidade = 2f;
    [SerializeField] private float distanciaPatrulha = 3f;
    private Vector3 posicaoInicial;
    private bool indoDireita = true;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        posicaoInicial = transform.position; 
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (indoDireita)
        {
            rb.linearVelocity = new Vector2(velocidade, rb.linearVelocity.y);

            if (transform.position.x >= posicaoInicial.x + distanciaPatrulha)
            {
                indoDireita = false;
            }
        }

        else
        {
            rb.linearVelocity = new Vector2(-velocidade, rb.linearVelocity.y);

            if (transform.position.x <= posicaoInicial.x - distanciaPatrulha)
            {
                indoDireita = true;

            }
                
            
        }
    }
}
