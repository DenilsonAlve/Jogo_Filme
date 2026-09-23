using UnityEngine;

public class VidaInim : MonoBehaviour
{
    public int vidaMaxima = 25;
    private int vidaAtual;
    public Caminho Canin;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void ReceberDano(int quantidadeDano)
    {
        vidaAtual -= quantidadeDano;
        Debug.Log(gameObject.name + " recebeu dano! Vida atual: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log(gameObject.name + " morreu!");

        Canin.QuantInimigos -= 1;

        Destroy(gameObject);

    }
}
