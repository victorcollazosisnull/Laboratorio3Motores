using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScenasPorEventos : MonoBehaviour
{
    public static class GameEvents
    {
        public static event Action GameOver;
        public static event Action Victory;

        public static void Perdiendo()
        {
            GameOver?.Invoke();
        }
        public static void Ganando()
        {
            Victory?.Invoke();
        }
    }
}
