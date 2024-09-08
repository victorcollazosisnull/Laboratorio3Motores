using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PlayerMovement : MonoBehaviour
{
    public static event Action<int> getMoney;
    public static event Action<int> getLife;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    public AudioSource _MonedaSource;
    public AudioSource _CorazonSource;
    [Header("Vida y Puntaje")]
    private VidaPlayer vidaPlayer;
    public int _cantidadPuntos = 10;
    public int _cantidadVida = 1;
    [SerializeField] private Puntaje puntos;
    [Header("Velocidad")]
    [SerializeField] private float _horizontal;
    public float speed;
    [Header("Salto")]
    public float jumpForce;
    [SerializeField] private bool jumping = false;
    [SerializeField] private bool jumpDoble = false;
    [SerializeField] private bool enSuelo = false;
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        vidaPlayer = GetComponent<VidaPlayer>();
    }
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }
    }
    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontal * speed, _rigidbody2D.velocity.y);

        if (jumping)
        {
            if (enSuelo)
            {
                _rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                jumpDoble = true;
                enSuelo = false; 
            }
            else if (jumpDoble)
            {
                _rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                jumpDoble = false; 
            }
            jumping = false; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true; 
            jumpDoble = true;
            jumping = false; 
        }
        else if (collision.gameObject.CompareTag("Muerte"))
        {
            ScenasPorEventos.GameEvents.Perdiendo();
        }
        else if (collision.gameObject.CompareTag("level2"))
        {
            SceneManager.LoadScene("SampleScene 2");
        }
        else if (collision.gameObject.CompareTag("Victory"))
        {
            ScenasPorEventos.GameEvents.Ganando();
        }       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("moneda"))
        {
            _MonedaSource.Play();
            Destroy(collision.gameObject);
            puntos.SumaPuntaje(_cantidadPuntos);        
            getMoney?.Invoke(_cantidadPuntos);
        }
        else if (collision.gameObject.CompareTag("heart"))
        {
            _CorazonSource.Play();
            vidaPlayer.RecuperarVida(1);
            Destroy(collision.gameObject);
            getLife?.Invoke(_cantidadVida);
        }
    }
}
