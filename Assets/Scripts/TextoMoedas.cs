using TMPro;
using UnityEngine;

public class TextoMoedas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoMoeda;

    private void OnEnable()
    {
        Moeda.OnMoedaColetada += AtualizarTexto;
    }

    private void OnDisable()
    {
        Moeda.OnMoedaColetada -= AtualizarTexto;
    }

    private void AtualizarTexto(int totalMoedas)
    {
        textoMoeda.text = "Moedas: " + totalMoedas;
    }
}
