using UnityEngine;

public class Prowler : MonoBehaviour
{
    public float velocidade = 50f;
    public int danoDoInimigo = 100;

    public bool deveSeguir = true;

    private Transform jogador; 

    void Start()
    {
        GameObject Personagem = GameObject.FindGameObjectWithTag("Player");
        if (Personagem != null)
        {
            jogador = Personagem.transform;
        }
    }

    void Update()
    {
        if (deveSeguir && jogador != null)
        {
            PerseguirPlayer();
        }
    }

    void PerseguirPlayer()
    {
        //Só x e z são do player
        Vector3 destinoNoChao = new Vector3(jogador.position.x, transform.position.y, jogador.position.z);

        transform.position = Vector3.MoveTowards(transform.position, destinoNoChao, velocidade * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            VidaP vidaDoJogador = collision.gameObject.GetComponent<VidaP>();
            if (vidaDoJogador != null)
            {
                vidaDoJogador.ReceberDano(danoDoInimigo);
                Debug.Log("Jogador foi pego pelo prowler");
            }
        }
    }
}
