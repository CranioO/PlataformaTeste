
using UnityEngine;

public class Porta : MonoBehaviour
{
    private  Vector3 deslocamento;
    private bool estaAberta = false;
    [SerializeField]private float velocidade = 2f;
    [SerializeField]private float distanciaSubida = 3f;


    private void Start()
    {
        deslocamento = transform.position + new Vector3(0, distanciaSubida, 0);
    }
    private void OnEnable()
    {
        Botao.OnBotaoAcionado += AbrirPorta;
    }

    private void OnDisable()
    {
        Botao.OnBotaoAcionado -= AbrirPorta;
    }

    private void AbrirPorta()
    {
        estaAberta = true;
    }

    private void Update()
    {
        if (estaAberta)
        {
            transform.position = Vector3.MoveTowards(transform.position, deslocamento, velocidade * Time.deltaTime);
        }
    }
}
