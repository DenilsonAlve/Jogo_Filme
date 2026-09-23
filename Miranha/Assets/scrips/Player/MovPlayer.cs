using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    public float velocidade = 5f;
    public Pulo Plar;

    private void Start()
    {
        Pulo Plar = GetComponent<Pulo>();
    }

    void Update()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 frenteDaCamera = Camera.main.transform.forward;
        Vector3 direitaDaCamera = Camera.main.transform.right;

        frenteDaCamera.y = 0;
        direitaDaCamera.y = 0;
        frenteDaCamera.Normalize();
        direitaDaCamera.Normalize();

        Vector3 direcaoFinal = (frenteDaCamera * moverVertical) + (direitaDaCamera * moverHorizontal);

        transform.Translate(direcaoFinal * velocidade * Time.deltaTime, Space.World);


        if (Plar.PodeNaum == false) 
        {
            velocidade = 8f;
        }
        else if (Plar.PodeNaum == true)
        {
            velocidade = 10f;
        }
    }
}
