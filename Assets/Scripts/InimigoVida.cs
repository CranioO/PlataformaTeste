using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    [SerializeField] private int vida = 1;

    public void Morrer(int dano)
    {
        vida -= dano;
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
