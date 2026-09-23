using UnityEngine;

public class LimiteVel : MonoBehaviour
{
    private Rigidbody rb;
    public float max = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > max) 
        {
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, max);
        }
    }
}
