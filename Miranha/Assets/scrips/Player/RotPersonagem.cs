using Unity.Mathematics;
using UnityEngine;

public class RotPersonagem : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 rotacaoDaCamera = cam.transform.eulerAngles;

        transform.rotation = Quaternion.Euler(0f, rotacaoDaCamera.y, 0f);
    }
}