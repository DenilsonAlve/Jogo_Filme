using System;
using UnityEditor;
using UnityEngine;

public class AtivarSeguir : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Prowler Tio;
    public GameObject Instruções;
    private float FoiN = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (FoiN < 1) 
            { 
            Pauser();
            }
        }

    }
    void Pauser() 
    {
       Instruções.SetActive(true);
       Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DESpausar() 
    {
        Instruções.SetActive(false);
        Time.timeScale = 1f;
        Tio.deveSeguir = true;
        FoiN = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
