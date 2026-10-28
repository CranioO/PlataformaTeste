using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            int proximaCena = SceneManager.GetActiveScene().buildIndex + 1;
            if (proximaCena < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(proximaCena);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
