using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonPausa : MonoBehaviour
{
    public ScenesControl scenesControl;
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menu;
    void Start()
    {
        menu.SetActive(false);
        botonPausa.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menu.SetActive(true);
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menu.SetActive(false);
    }
    public void Quit()
    {
        scenesControl.volverAlMenu();
    }
}
