using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float velocidade = 3f; 
    public int danoDoInimigo = 10;


    internal Transform TransfPlayr; 
    private GameObject RealPlayer;
    internal bool seguir = false;

    public float VeloRot;
    

    private void Start()
    {
        RealPlayer = GameObject.FindGameObjectWithTag("Player");
        if (RealPlayer != null)
        {
            TransfPlayr = RealPlayer.transform;
        }
    }
    void Update()
    {
        if (seguir && TransfPlayr != null)
        {
            PerseguirJogador();
        }
    }

    void PerseguirJogador()
    {
        transform.position = Vector3.MoveTowards(transform.position, TransfPlayr.position, velocidade * Time.deltaTime);

        Vector3 playerChao = new Vector3(TransfPlayr.position.x, transform.position.y, TransfPlayr.position.z);
        Vector3 direcao = playerChao - transform.position;

        if (direcao != Vector3.zero)
        {
            //desconbre a rotação final
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);

            //Vai girando lentinho
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, VeloRot * Time.deltaTime);
        }

    }

   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            VidaP vidaDoJogador = collision.gameObject.GetComponent<VidaP>();
            if (vidaDoJogador != null)
            {
                vidaDoJogador.ReceberDano(danoDoInimigo);
                Debug.Log("Jogador foi acertado");
            }
        }
    }
}
