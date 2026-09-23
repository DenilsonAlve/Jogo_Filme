using UnityEngine;

public class Caminho : MonoBehaviour
{

    public GameObject seta;
    public GameObject Ponto;
    public float QuantInimigos = 6;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (QuantInimigos <= 0) 
            {
                Passou();
            }
    }

    void Passou() 
    {
        seta.SetActive(true);
        Ponto.SetActive(false);
    }

}
