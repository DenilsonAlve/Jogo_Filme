using UnityEngine;

public class ATQhitbox: MonoBehaviour
{
    public int dano = 25;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("inimigo"))
        {
            VidaInim vidaDoInimigo = other.GetComponent<VidaInim>();
            VidaCreme VidaDoCreme = other.GetComponent<VidaCreme>();

            if (vidaDoInimigo != null)
            {
                vidaDoInimigo.ReceberDano(dano);
            }
            else if (VidaDoCreme != null)
            {
                VidaDoCreme.ReceberDano(dano);
            }
        }
    }
}
