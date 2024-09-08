using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ScenesControl : MonoBehaviour
{
    public void CambioEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void volverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void Reintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    private void GameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver");
    }
    private void Victoria()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Resultado"); 
    }
    void OnEnable()
    {
        ScenasPorEventos.GameEvents.GameOver += GameOver;
        ScenasPorEventos.GameEvents.Victory += Victoria;
    }
    void OnDisable()
    {
        ScenasPorEventos.GameEvents.GameOver -= GameOver;
        ScenasPorEventos.GameEvents.Victory -= Victoria;
    }
}
