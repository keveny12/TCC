using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody2D;
    public float _playerVelocidade;
    private Vector2 _playerDireção;
    private Animator anim;
    public float VelocidadePoção;
    public float velocidadeEspinho;
    
    

    public GameObject tiroDoPlayer;
    public Transform localDoDisparo;
    public Transform localDoDisparoEsquerda;
    public Transform localDoDisparoDireita;
    public float tempoMaximoDosTirosDuplus;
    public float tempoAtualDosTirorsDuplos;
    public bool temTiroDuplo;
    public Transform Arma;
    public bool temPocao;
    public float tempoMaximoDaPocao;
    public float tempoAtualDaPocao;
    public bool temEspinho;
    public float tempoMaximoDoEspinho;
    public float tempoAtualDoEspinho;


    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        temTiroDuplo = false;
        tempoAtualDosTirorsDuplos = tempoMaximoDosTirosDuplus;
        tempoAtualDaPocao = tempoMaximoDaPocao;
        tempoAtualDoEspinho = tempoMaximoDoEspinho;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        _playerDireção = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        Atirar();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (mousePos - Arma.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Arma.localRotation = Quaternion.Euler(0,0,angle);

        if (temTiroDuplo == true)
        {
            tempoAtualDosTirorsDuplos -= Time.deltaTime;
            if (tempoAtualDosTirorsDuplos <= 0)
            {
                DesativarTiroDuplo();
            }
        }

        if (temPocao == true)
        {
            tempoAtualDaPocao -= Time.deltaTime;
            if (tempoAtualDaPocao <= 0)
            {
                DesativarPocao();
            }
        }
        
        if (temEspinho == true)
        {
            tempoAtualDoEspinho -= Time.deltaTime;
            if (tempoAtualDoEspinho <= 0)
            {
                DesativarEspinho();
            }
        }
    }

    void FixedUpdate()
    {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDireção * _playerVelocidade * Time.fixedDeltaTime);
        if (_playerDireção.x < 0)
        {
            anim.SetInteger("transition",1);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (_playerDireção.x > 0)
        {
            anim.SetInteger("transition",1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (_playerDireção.x == 0) 
        {
            anim.SetInteger("transition",0);
        }
    }

    private void Atirar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (temTiroDuplo == false)
            {
                Instantiate(tiroDoPlayer, localDoDisparo.position, Arma.localRotation );
            }
            else
            {
                Instantiate(tiroDoPlayer, localDoDisparoEsquerda.position, localDoDisparoEsquerda.rotation);
                Instantiate(tiroDoPlayer, localDoDisparoDireita.position, localDoDisparoDireita.rotation);
            }
            
        }
    }

    private void DesativarTiroDuplo()
    {
        temTiroDuplo = false;
        tempoAtualDosTirorsDuplos = tempoMaximoDosTirosDuplus;
    }

    private void pocao()
    {
        if (temPocao == false)
        {
            //_playerVelocidade = _playerVelocidade;
        }
        else
        {
            //_playerVelocidade = VelocidadePoção;
        }
    }
    private void Espinho()
    {
        if (temEspinho == false)
        {
            //_playerVelocidade = _playerVelocidade;
        }
        else
        {
            //_playerVelocidade = velocidadeEspinho;
        }
    }
    private void DesativarPocao()
    {
        temPocao = false;
        tempoAtualDaPocao = tempoMaximoDaPocao;
    }
    private void DesativarEspinho()
    {
        temEspinho = false;
        tempoAtualDoEspinho = tempoMaximoDoEspinho;
    }
}
