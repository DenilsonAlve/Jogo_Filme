using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 

public class VidaP : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaAtual;

    public Image barraDeVidaImagem;
    public TextMeshProUGUI qtdVida; 

    void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarInterface();
    }

    public void ReceberDano(int quantidadeDano)
    {
        vidaAtual -= quantidadeDano;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);

        AtualizarInterface();

        Debug.Log(gameObject.name + " recebeu dano! Vida atual: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void AtualizarInterface()
    {
        barraDeVidaImagem.fillAmount = (float)vidaAtual / vidaMaxima;
        qtdVida.text = vidaAtual + " / " + vidaMaxima;
    }

    void Morrer()
    {
        TelaMorte.playerMorreu = true;
        SceneManager.LoadScene("Jogo");
        SceneManager.LoadScene("Cabo");
        Debug.Log(gameObject.name + " morreu!");
        Destroy(gameObject);
    }
}
