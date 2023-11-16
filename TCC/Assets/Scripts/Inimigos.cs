using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inimigos : MonoBehaviour
{
    public Transform alvo;
    [SerializeField] private float raioVisao;
    [SerializeField] private LayerMask layerAreaVisao;
    private Transform Target;
    public float VelocidadeDoInimigo;
    public int vidaMaximaDoInimigo;
    public int vidaAtualDoInimigo;
    public int chanceParaDropar;
    public bool temEscudo;
    public GameObject escudoDoInimigo;
    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;
    public GameObject itemParaDropar;
    public bool inimigoAtirador;
    public int danoParaDar;

    // Start is called before the first frame update
    void Start()
    {
       
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        ProcurarJogador();
        if (this.alvo != null)
        {
            MovimentoInimigo();
            if (inimigoAtirador == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.position, VelocidadeDoInimigo * Time.deltaTime);
            }
            if (inimigoAtirador == true)//se for atirador vai atirar
            {
                                           
            }
        }
        else
        {
            //parar de mover
        }
        
        
    }
    private void MovimentoInimigo()
    {
        transform.Translate(Vector3.up * VelocidadeDoInimigo * Time.deltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<VidaDoJogador>().DanoJogador(danoParaDar);
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
    }

    private void ProcurarJogador()
    {
       Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, this.layerAreaVisao);
       if (colisor != null)
       {
           this.alvo = colisor.transform;
       }
       else
       {
           this.alvo = null;
       }
    }

    public void DanoInimigo(int danoParaReceber)
    {
        if (temEscudo == false)
        {
            vidaAtualDoInimigo -= danoParaReceber;

            if (vidaAtualDoInimigo <= 0)
            {
                //GameManager.Instance.AumentoPontos(darPontos);
                int numeroAleatorio = Random.Range(0, 100); //cria variavel que sortea um numero aleatorio para dropar o power up
                if (numeroAleatorio <= chanceParaDropar) //porcentagem da chance de dropar power up
                {
                    Instantiate(itemParaDropar, transform.position, Quaternion.Euler(0f, 0f, 0f));
                }
                Destroy(this.gameObject);
            }
        }
        else
        {
            vidaAtualDoEscudo -= danoParaReceber;
            if (vidaAtualDoEscudo <= 0)
            {
                escudoDoInimigo.SetActive(false);//desativa o escudo
                temEscudo = false;
            }
        }
    }
    
}
