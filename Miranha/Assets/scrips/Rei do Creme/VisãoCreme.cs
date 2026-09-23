using UnityEngine;

public class VisãoCreme : MonoBehaviour
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
        ReiCreme Fisk = GetComponentInParent<ReiCreme>();

        if (other.CompareTag("Player"))
        {
            Fisk.seguir = true;
            Fisk.EmCooldown = true;
            Debug.Log("Inimigo viu o jogador!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        ReiCreme Fisk = GetComponentInParent<ReiCreme>();

        if (other.CompareTag("Player"))
        {
            Fisk.seguir = false;
            Fisk.EmCooldown = true;
            Debug.Log("Jogador escapou da visão!");
        }
    }

}
