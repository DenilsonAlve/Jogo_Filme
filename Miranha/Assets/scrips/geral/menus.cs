using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class menus : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private VideoPlayer meuVideoPlayer;
    public GameObject Telinha;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Telinha.SetActive(true);

        meuVideoPlayer = GetComponent<VideoPlayer>();
        meuVideoPlayer.loopPointReached += QuandoOVideoAcabar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarCutscene()
    {
        if (meuVideoPlayer != null)
        {
            meuVideoPlayer.Play();
            Telinha.SetActive(false);
        }
    }

    void QuandoOVideoAcabar(VideoPlayer vp)
    {
        Iniciar();
    }

    public void Iniciar() 
    {
        SceneManager.LoadScene("Jogo");
    }

    public void Menu() 
    {
        SceneManager.LoadScene("Menu");
    }



}
