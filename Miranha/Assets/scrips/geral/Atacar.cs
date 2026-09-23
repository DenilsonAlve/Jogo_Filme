using UnityEngine;

public class Atacar : MonoBehaviour
{
    public GameObject prefabAtaque;
    public Transform pontoDeAtaque; 
    private bool EMCouldawn = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && EMCouldawn == false)
        {
            EMCouldawn = true;
            UsarAtq();
            Invoke("TempoParaAtaquar", 1f);
        }
    }

    void TempoParaAtaquar() 
    {
        EMCouldawn = false;
    }

    void UsarAtq()
    {
        GameObject cloneDoAtaque = Instantiate(prefabAtaque, pontoDeAtaque.position, pontoDeAtaque.rotation);

        cloneDoAtaque.transform.SetParent(pontoDeAtaque);

        Destroy(cloneDoAtaque, 0.2f);
    }
}
