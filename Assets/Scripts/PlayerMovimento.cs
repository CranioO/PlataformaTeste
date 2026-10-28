
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovimento : MonoBehaviour
{
    private bool estaNoChao;
    [SerializeField] private float raioChecagem = 0.15f;
    [SerializeField] private float forcaPulo = 10f;
    [SerializeField] private Transform checagemChao;
    [SerializeField] private LayerMask camadaChao;
    [SerializeField]float velocidade = 5f;
    private Controles controls;
    private Rigidbody2D rb;
    public float VelocidadeX => rb.linearVelocity.x;
    public float VelocidadeY => rb.linearVelocity.y;
    public bool EstaNoChao => estaNoChao;
    private Vector2 movimento;
    [SerializeField] private int maxPulos = 2;
    private int pulosRestantes;
    private bool estaNoChaoAnterior;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
       
    }


    void Start()
    {
        controls = new Controles();
        controls.Player.Enable();
        controls.Player.Pulo.performed += Pular;
    }

    private void OnDestroy()
    {
        controls.Player.Pulo.performed -= Pular;
        controls.Player.Disable();
        
    }

    private void Pular(InputAction.CallbackContext context)
    {
        if (pulosRestantes > 0 && Time.timeScale > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
            pulosRestantes--;
        }
    }

    
    void Update()
    {
       movimento = controls.Player.Move.ReadValue<Vector2>();
        bool novoEstaNoChao = Physics2D.OverlapCircle(checagemChao.position, raioChecagem, camadaChao) && rb.linearVelocity.y <= 0.1f;
        
        if (novoEstaNoChao && !estaNoChaoAnterior)
        {
            StartCoroutine(Squash());
        }
        estaNoChao = novoEstaNoChao;
        
        if (estaNoChao)
        {
            pulosRestantes = maxPulos;
        }
        estaNoChaoAnterior = estaNoChao;
    }

    private IEnumerator Squash()
    {
        transform.localScale = new Vector3(1.3f, 0.7f, 1f);
        yield return new WaitForSeconds(0.1f);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimento.x * velocidade, rb.linearVelocity.y);
    }
}
