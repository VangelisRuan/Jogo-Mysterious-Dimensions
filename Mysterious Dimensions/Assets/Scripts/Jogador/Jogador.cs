using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Jogador : MonoBehaviour
{

    public GameObject menuMorte;

    [SerializeField]
    private int _vidaMax = 3;

    [SerializeField]
    private int _vidaRestante;

    [SerializeField]
    private Vidas _vidas;

    private float _tempoDeResistencia = 1.5f;

    public SpriteRenderer sprite;

    [SerializeField]
    private Inventario _inventario;

    [SerializeField]
    public List<string> _itemsDeInventario = new List<string>();

    private Animator _animator;

    [SerializeField]
    private AudioClip _som;

    [SerializeField]
    private AudioClip _som2;

    public void Awake()
    {
        AtualizaVidaUI();
        _animator = GetComponent<Animator>();
    }

    private void start()
    {
        menuMorte.SetActive(false);
        Time.timeScale = 1f;
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        if (GuardarItems._itemsDeInventario != null)
        {
            Debug.Log("entrando");
            foreach (string i in GuardarItems._itemsDeInventario)
            {
                AdicionaItem(i);
                _inventario.AtualizaInventario(i);
            }
        }
    }

    void Update()
    {
        _animator.SetBool("LevaDano", false);

        sprite.enabled = true;

        sprite.color = new Color(1f, 1f, 1f, 1f);

        _tempoDeResistencia += Time.deltaTime;

        if(_tempoDeResistencia <= 1.5f)
        {
            sprite.color = new Color(1f, 0, 0, 1f);
        }

        if(_tempoDeResistencia >= 0.10f && _tempoDeResistencia <= 0.20f || _tempoDeResistencia >= 0.30f && _tempoDeResistencia <= 0.40f ||
            _tempoDeResistencia >= 0.50f && _tempoDeResistencia <= 0.60f || _tempoDeResistencia >= 0.70f && _tempoDeResistencia <= 0.80f ||
            _tempoDeResistencia >= 0.90f && _tempoDeResistencia <= 1.00f || _tempoDeResistencia >= 1.10f && _tempoDeResistencia <= 1.20f ||
            _tempoDeResistencia >= 1.30f && _tempoDeResistencia <= 1.40f)
        {
            sprite.enabled = false;
        }

        if (_tempoDeResistencia <= 0.25f)
        {
            _animator.SetBool("LevaDano", true);
        }
    }

    public void AdicionaItem(string nomeItem)
    {
        _itemsDeInventario.Add(nomeItem);
    }

    public bool TemItem(string nomeItem)
    {
        var resultado = _itemsDeInventario.Contains(nomeItem);
        return resultado;
    }

    public void TomaDano(int dano)
    {

        if (_tempoDeResistencia >= 1.5f)
        {
            if (_som)
                AudioSource.PlayClipAtPoint(_som, transform.position);

            _vidaRestante -= dano;

            _tempoDeResistencia = 0;

        }

        if (_vidaRestante != 3)
        {
            AtualizaVidaUI();
        }
        if (_vidaRestante < 0)
        {
            Morre();
        }
    }

    public void GanhaVida(int vida)
    {
        if (_vidaRestante < 3)
        {
            _vidaRestante += vida;
            AtualizaVidaUI();
        }
    }

    public void Morre()
    {
        menuMorte.SetActive(true);
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
        gameObject.SetActive(false);
        if (_som2)
            AudioSource.PlayClipAtPoint(_som2, transform.position);
    }

    public void AtualizaVidaUI()
    {
        _vidas.AtualizaVidas(_vidaRestante, _vidaMax);
    }

    public void AtualizaInventarioUI()
    {
        string nome_do_item = _itemsDeInventario[_itemsDeInventario.Count - 1];
        _inventario.AtualizaInventario(nome_do_item);
    }

    public void LimparItems()
    {
        _itemsDeInventario.Clear();
    }

}
