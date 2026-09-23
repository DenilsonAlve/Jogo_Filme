using UnityEngine;

public class TelaMorte : MonoBehaviour
{
    public static TelaMorte Instancia;

    public static bool playerMorreu = false;
    public static bool KPin = true;

    void Awake()
    {
        //Garante que só vai existir UM gerenciador desse no jogo todo
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject); // n deixa que este objeto suma na troca de cena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }
}
