using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{

    private bool pulo = false;

    public float velocidadeDoMovimento;
    private float _aumentoDaVelocidade = 0;
    public float forcaDoPulo = 300;
    public Transform checarChao;
    public Transform checarChao2;

    private bool estaNoChao = false;
    private bool estaNoChao2 = false;
    private bool ataque = false;
    private Rigidbody2D rb2d;

    int contadorDePulo = 0;

    private bool _ataqueHabilitado = true;

    private float _limiteDeAtaque = 0;

    [SerializeField]
    private Collider2D _areaDeAtaque;

    private Animator anim;

    [SerializeField]
    private InventarioAtaque _inventarioAtaque;

    [SerializeField]
    private List<string> _itemsDeInventarioAtaque = new List<string>();

    private bool _luvaDeFogoHabilitada;

    private bool _luvaDeChoqueHabilitada;

    [SerializeField]
    private Poderzinho _poderzinho;

    [SerializeField]
    private Poderzinho2 _poderzinho2;

    public int _uso;

    private AudioSource _som;

    [SerializeField]
    private AudioClip _som2;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        _som = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        estaNoChao = Physics2D.Linecast(transform.position, checarChao.position, 1 << LayerMask.NameToLayer("Chao"));

        estaNoChao2 = Physics2D.Linecast(transform.position, checarChao2.position, 1 << LayerMask.NameToLayer("Chao"));

        anim.SetBool("NoChao", estaNoChao);
        anim.SetBool("NoChao", estaNoChao2);

        if (estaNoChao || estaNoChao2)
        {
            anim.SetBool("Pulando", false);
        }

        if (ataque)
        {

        }

        _limiteDeAtaque += Time.deltaTime;
        _aumentoDaVelocidade += Time.deltaTime;

        if (_aumentoDaVelocidade > 1 && velocidadeDoMovimento < 10)
        {
            velocidadeDoMovimento += 0.001f;
            _aumentoDaVelocidade = 0;
        }

    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(velocidadeDoMovimento, rb2d.velocity.y);

        if (pulo)
            {
                anim.SetBool("Pulando", true);
                _som.Play();
                rb2d.AddForce(new Vector2(0, forcaDoPulo));
                pulo = false;
            }

    }

    public void AdicionaItemAtaque(string nomeItem)
    {
        _itemsDeInventarioAtaque.Add(nomeItem);

        if (TemItemAtaque("LuvaDeFogo"))
        {
            HabilitaLuvaDeFogo();
            _ataqueHabilitado = false;
            _luvaDeChoqueHabilitada = false;
        }

        if (TemItemAtaque("LuvaDeChoque"))
        {
            HabilitaLuvaDeChoque();
            _ataqueHabilitado = false;
            _luvaDeFogoHabilitada = false;
        }
    }

    public void HabilitaLuvaDeFogo()
    {
        _luvaDeFogoHabilitada = true;
        if (_uso > 0)
        {
            _uso = _uso + 0;
        }
        else
        {
            _uso = _uso + 5;
        }
    }

    public void HabilitaLuvaDeChoque()
    {
        _luvaDeChoqueHabilitada = true;
        if (_uso > 0)
        {
            _uso = _uso + 0;
        }
        else
        {
            _uso = _uso + 5;
        }
    }

    public bool TemItemAtaque(string nomeItem)
    {
        var resultado = _itemsDeInventarioAtaque.Contains(nomeItem);
        return resultado;
    }

    public void AtualizaInventarioAtaqueUI()
    {
        string nome_do_item = _itemsDeInventarioAtaque[_itemsDeInventarioAtaque.Count - 1];
        _inventarioAtaque.AtualizaInventarioAtaque(nome_do_item);
    }

    public void LimparItemsAtaque()
    {
        _itemsDeInventarioAtaque.Clear();
    }


    public void Pulo()
    {
        if (estaNoChao || estaNoChao2)
        {
            contadorDePulo = 0;
            contadorDePulo++;
            pulo = true;
        }else{ 
            PuloDuplo();
        }
    }

    public void PuloDuplo() 
    {
            if (contadorDePulo < 2)
            {
                anim.SetBool("Pulando", true);
                _som.Play();
                contadorDePulo++;
                rb2d.AddForce(new Vector2(0, forcaDoPulo - 150));
            }
    }

    public void Ataque()
    {
        if (_ataqueHabilitado == true && _limiteDeAtaque > 0.3f)
        {
            ataque = true;
            anim.SetTrigger("AtaqueTrigger");
            _limiteDeAtaque = 0;
        }

        if (_luvaDeFogoHabilitada == true && _uso > 0)
        {
            _poderzinho.Atira();
            _uso = _uso - 1;
            anim.SetTrigger("PoderTrigger");

            if (_uso == 0)
            {
                _ataqueHabilitado = true;
                _inventarioAtaque.ResetaLista();
                LimparItemsAtaque();
            }
        }

        if (_luvaDeChoqueHabilitada == true && _uso > 0)
        {
            _poderzinho2.Atira();
            _uso = _uso - 1;
            anim.SetTrigger("PoderDoisTrigger");

            if (_uso == 0)
            {
                _ataqueHabilitado = true;
                _inventarioAtaque.ResetaLista();
                LimparItemsAtaque();
            }
        }
    }

    public void IniciaAtaque()
    {
        if (_som2)
            AudioSource.PlayClipAtPoint(_som2, transform.position);
        _areaDeAtaque.enabled = true;
    }

    public void TerminaAtaque()
    {
        _areaDeAtaque.enabled = false;
    }

}
