using System;
using UnityEngine;

public class MoedaMovel : MonoBehaviour
{
    private Vector3 posicaoInicial;
    [SerializeField]private float altura = 3f;
    [SerializeField]private float velocidade = 2f;
    [SerializeField] private int valor = 1;
    public static event Action<int> OnMoedaColetada;
    
    void Start()
    {
        posicaoInicial = transform.position;
    }

    private void Update()
    {
        float novoY = posicaoInicial.y + Mathf.Sin(Time.time * velocidade) * altura;
        transform.position = new Vector3(transform.position.x, novoY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            GerenciadorDeJogo.totalMoedas += valor;
            OnMoedaColetada?.Invoke(GerenciadorDeJogo.totalMoedas);
            Destroy(gameObject);
        }
    }
}
