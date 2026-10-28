using System;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    [SerializeField] private int valor = 1;
    public static event Action<int> OnMoedaColetada;

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
