using System;
using UnityEngine;

public class Botao : MonoBehaviour
{
    public static event Action OnBotaoAcionado;
    private bool foiAcionado = false;

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (!foiAcionado && outro.CompareTag("Player"))
        {
            foiAcionado = true;
            OnBotaoAcionado?.Invoke();
        }
    }
}
