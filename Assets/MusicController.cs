using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;
    public static bool playMusicOnStart = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Mantiene el objeto entre escenas
    }

    void Start()
    {
        if (playMusicOnStart && musicSource != null)
        {
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // Llamado desde JS para detener la música
    public void StopMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    // JS puede indicar si se debe volver a reproducir la música tras reiniciar
    public void SetPlayMusicOnStart(string value)
    {
        playMusicOnStart = value == "true";
    }
}