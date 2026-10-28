using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("fase1");
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
