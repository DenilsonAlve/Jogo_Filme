using Unity.VisualScripting;
using UnityEngine;

public class Pulo : MonoBehaviour
{
    private Rigidbody Ocorno;
    public float Forfapulo = 500f;
    public bool PodeNaum = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ocorno = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PodeNaum)
        {
            Vector3 direY = Vector3.up;
            Ocorno.AddForce(direY * Forfapulo * Time.fixedDeltaTime);
            PodeNaum = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        PodeNaum = true;
    }
}