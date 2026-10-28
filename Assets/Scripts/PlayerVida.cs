using UnityEngine;
using System;

public class PlayerVida : MonoBehaviour
{
    [SerializeField] private int vidaMaxima = 3;
    [SerializeField] private float forcaImpulsoDerrota = 6f;
    private int vidaAtual;
    public static event Action<int, int> OnVidaMudou;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        bool estaCaindoPorCima = transform.position.y > colisao.transform.position.y && rb.linearVelocity.y <= 0.1f;        if (colisao.gameObject.CompareTag("Inimigo"))
        {
            if (estaCaindoPorCima)
            {
                InimigoVida vidaDoInimigo = colisao.gameObject.GetComponent<InimigoVida>();
                vidaDoInimigo.Morrer(1);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaImpulsoDerrota);
            }
            else
            {
                TomarDano(1);
            }
        }
    }
    void Start()
    {
        Checkpoint.posicaoCheck = transform.position;
        vidaAtual = vidaMaxima;
        OnVidaMudou?.Invoke(vidaAtual, vidaMaxima);
    }

    public void TomarDano(int dano)
    {
        vidaAtual = vidaAtual - dano;
        OnVidaMudou?.Invoke(vidaAtual, vidaMaxima);        
        if (vidaAtual <= 0)
        {
            Morrer();
        }

    }

    private void Morrer()
    {
        transform.position = Checkpoint.posicaoCheck;
    }
}
