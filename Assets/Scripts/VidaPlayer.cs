using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class VidaPlayer : MonoBehaviour
{
    public int maxVida = 10;
    public int vidaActual;
    public Image BarraDeVida;
    public static event Action<int> vidaActualizada;
    void Start()
    {
        vidaActual = maxVida;
        ActualizarBarraVida();
    }
    public void Damage(int cantidad)
    {
        vidaActual = vidaActual - cantidad;
        if (vidaActual <= 0)
        {
            vidaActual = 0;
            ScenasPorEventos.GameEvents.Perdiendo();
        }
        ActualizarBarraVida();
        vidaActualizada?.Invoke(vidaActual);
    }
    public void RecuperarVida(int cantidad)
    {
        vidaActual = vidaActual + cantidad;
        if (vidaActual > maxVida)
        {
            vidaActual = maxVida;
        }
        ActualizarBarraVida();
        vidaActualizada?.Invoke(vidaActual);
    }
    void ActualizarBarraVida()
    {
        BarraDeVida.fillAmount = (float)vidaActual / (float)maxVida;
    }
}
