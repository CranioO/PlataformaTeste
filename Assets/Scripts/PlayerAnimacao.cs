using UnityEngine;

public class PlayerAnimacao : MonoBehaviour
{
    private Animator animator;
    private PlayerMovimento playermovimento;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playermovimento = GetComponent<PlayerMovimento>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetFloat("velocidadeX", Mathf.Abs(playermovimento.VelocidadeX));
        animator.SetFloat("VelocidadeY", playermovimento.VelocidadeY);
        animator.SetBool("estaNoChao", playermovimento.EstaNoChao);

        if(playermovimento.VelocidadeX > 0.1f)
        {
            spriteRenderer.flipX = false;
        }

        if(playermovimento.VelocidadeX < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
