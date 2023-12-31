using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Lagarto : MonoBehaviour
{
    public Transform alvo;
    [SerializeField] private float raioVisao;
    [SerializeField] private LayerMask layerAreaVisao;
    public GameObject laserDoLagarto;
    public Transform localDoDisparo;
    private Rigidbody2D rig;
    public float velocidade;
    public float tempoMaximoEntreOsLasers;
    public float tempoAtualDosLasers;
    public bool direcao;
    public int vidaMaximaDoInimigo;
    public int vidaAtualDoInimigo;
    public GameObject itemParaDropar;
    public int chanceParaDropar;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    // Update is called once per frame
    
    
    void FixedUpdate()
    {

        ProcurarJogador();
        if (this.alvo != null)
        {
            rig.velocity = Vector2.left * velocidade;
        }



    }

    private void Update()
    {
        AtirarLaser();
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;
        if (tempoAtualDosLasers <= 0)
        {
            Instantiate(laserDoLagarto, localDoDisparo.position, Quaternion.Euler(0f, 0f, 90f ));
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
        }
    }
    public void DanoInimigo(int danoParaReceber)
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
}
