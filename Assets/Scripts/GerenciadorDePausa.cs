using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GerenciadorDePausa : MonoBehaviour
{
    [SerializeField] private GameObject painelPausa;
    private Controles controls;

    private void Start()
    {
        controls = new Controles();
        controls.Player.Enable();
        controls.Player.Pausar.performed += AlternarPausa;
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
        controls.Player.Pausar.performed -= AlternarPausa;

    }

    public void PausarJogo()
    {
        Time.timeScale = 0f;
        painelPausa.SetActive(true);
    }

    public void ContinuarJogo()
    {
        Time.timeScale = 1f;
        painelPausa.SetActive(false);
    }

    public void VoltarAoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private void AlternarPausa(InputAction.CallbackContext context)
    {
        if(Time.timeScale > 0)
        {
            PausarJogo();
        }
        else
        {
            ContinuarJogo();
        }
    }

    
}
