using UnityEngine;

public class BalancoTeia : MonoBehaviour
{
    public LineRenderer lr;
    public Transform maoDoPersonagem;
    public Camera cam;

    public LayerMask Prediu; //Layer dos obtaculo
    public LayerMask Nimigs; //Layer dos bixo

    private Vector3 pontoDeImpacto;
    private SpringJoint joint;
    private Transform objetoAtingido; 

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) IniciarTeia();
        if (Input.GetMouseButtonUp(1)) PararTeia();
    }

    void LateUpdate()
    {
        DesenharTeia();
    }

    void IniciarTeia()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 150f, Prediu | Nimigs))
        {
            pontoDeImpacto = hit.point;

            //Criando a joint no player
            joint = gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;

            Rigidbody rbDoObjeto = hit.collider.GetComponent<Rigidbody>();

            if (((1 << hit.collider.gameObject.layer) & Nimigs) != 0 && rbDoObjeto != null)
            {
                //Conecta no objeto puxante
                joint.connectedBody = rbDoObjeto;
                joint.connectedAnchor = Vector3.zero; 

                objetoAtingido = hit.transform; 
            }
            else
            {
                //Conecta no mapa
                joint.connectedAnchor = pontoDeImpacto;
                objetoAtingido = null; 
            }

            //Distância das joint
            float distanciaDoPonto = Vector3.Distance(transform.position, pontoDeImpacto);
            joint.maxDistance = distanciaDoPonto * 0f;
            joint.minDistance = distanciaDoPonto * 0f;

            //Força das joint
            joint.spring = 20f;
            joint.damper = 10f;
            joint.massScale = 1f;

            lr.positionCount = 2;
        }
    }

    void PararTeia()
    {
        lr.positionCount = 0;
        Destroy(joint);
        objetoAtingido = null;
    }

    void DesenharTeia()
    {
        if (!joint) return;

        lr.SetPosition(0, maoDoPersonagem.position);

        if (objetoAtingido != null)
        {
            lr.SetPosition(1, objetoAtingido.position);
        }
        else
        {
            lr.SetPosition(1, pontoDeImpacto);
        }
    }
}
