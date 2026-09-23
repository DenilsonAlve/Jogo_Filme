using UnityEngine;

public class TipoTelaLer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Perdeu;
    public GameObject Ganhou;

    void Start()
    {
        bool morreu = TelaMorte.playerMorreu;
        bool Cremer = TelaMorte.KPin;

        if (morreu == true) 
        {
            Perdeu.SetActive(true);
            Ganhou.SetActive(false);
        }
        else if (Cremer == false)
        {
            Perdeu.SetActive(false);
            Ganhou.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
