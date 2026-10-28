using UnityEngine;
using TMPro;

public class TextoVida : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoVida; 


    private void OnEnable()
    {
        PlayerVida.OnVidaMudou += AtualizarTexto;
    }

    private void OnDisable()
    {
        PlayerVida.OnVidaMudou -= AtualizarTexto;
    }

    private void AtualizarTexto(int vidaAtual, int VidaMaxima)
    {
        textoVida.text = "vida: " + vidaAtual;
    }

}
