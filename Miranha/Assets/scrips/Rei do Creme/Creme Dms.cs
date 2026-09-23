using UnityEngine;

public class ReiCreme : MonoBehaviour
{
    public float velocidade = 3f;
    public int danoDoInimigo = 10;

    internal Transform jogador;
    internal bool seguir = false;
    private GameObject PosJogador;

    public GameObject hitbox;
    public Transform OndeAtaque;
    internal bool EmCooldown;

    public float VelRot;

    private void Start()
    {
        PosJogador = GameObject.FindGameObjectWithTag("Player");
        if (PosJogador != null)
        {
            jogador = PosJogador.transform;
        }
    }

    void Update()
    {
        if (seguir && jogador != null)
        {
            PerseguirJogador();
        }

        if (seguir && EmCooldown && jogador != null) 
        {
            UsarAtq();
            EmCooldown = false;
            Invoke("TempoAtaque", 3.5f);
        }
    }
    void TempoAtaque() 
    {
        EmCooldown = true;
    }

    void PerseguirJogador()
    {
        transform.position = Vector3.MoveTowards(transform.position, jogador.position, velocidade * Time.deltaTime);

        Vector3 playerChao = new Vector3(jogador.position.x, transform.position.y, jogador.position.z);
        Vector3 direcao = playerChao - transform.position;

        if (direcao != Vector3.zero) 
        {
            //desconbre a rotação final
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);

            //Vai girando lentinho
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, VelRot * Time.deltaTime);
        }

    }


    void UsarAtq()
    {
        //Cria o prefab que é a hitbox do atq
        GameObject cloneDoAtaque = Instantiate(hitbox, OndeAtaque.position, OndeAtaque.rotation);

        //Faz o atque acompanhar o player
        cloneDoAtaque.transform.SetParent(OndeAtaque);

        //Apaga depois de 0.2 segundinhos
        Destroy(cloneDoAtaque, 0.2f);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            VidaP vidaDoJogador = collision.gameObject.GetComponent<VidaP>();
            if (vidaDoJogador != null)
            {
                vidaDoJogador.ReceberDano(danoDoInimigo);
                Debug.Log("O inimigo atacou o jogador!");
            }
        }
    }
}
