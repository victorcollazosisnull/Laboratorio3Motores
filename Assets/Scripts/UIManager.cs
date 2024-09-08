using UnityEngine;
public class UIManager : MonoBehaviour
{
    void OnEnable()
    {
        VidaPlayer.vidaActualizada += ActualizarVida;
        Puntaje.actualizarPunt += ActualizarPuntaje;
    }
    void OnDisable()
    {
        VidaPlayer.vidaActualizada -= ActualizarVida;
        Puntaje.actualizarPunt -= ActualizarPuntaje;
    }

    private void ActualizarVida(int nuevaVida)
    {
        Debug.Log("Vida: " + nuevaVida);
    }

    private void ActualizarPuntaje(int nuevoPuntaje)
    {
        Debug.Log("Puntaje: " + nuevoPuntaje);
    }
}
