using UnityEngine;

public class DetectarPlayer : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        Inimigo nims = GetComponentInParent<Inimigo>();

        if (other.CompareTag("Player"))
        {
            nims.seguir = true;
            Debug.Log("Inimigo viu o jogador!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        Inimigo nims = GetComponentInParent<Inimigo>();

        if (other.CompareTag("Player"))
        {
            nims.seguir = false;
            Debug.Log("Jogador escapou da visão!");
        }
    }

}
