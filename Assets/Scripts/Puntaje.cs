using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Puntaje : MonoBehaviour
{
    private float puntaje;
    private TextMeshProUGUI textMesh;
    public static event Action<int> actualizarPunt;
    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        puntaje = 0;
        ActualizarTexto();
    }
    public void SumaPuntaje(int puntos)
    {
        puntaje = puntaje + puntos;
        ActualizarTexto();
        actualizarPunt?.Invoke(puntos);
    }
    private void ActualizarTexto()
    {
        textMesh.text = "Puntaje: " + puntaje.ToString();
    }
}
