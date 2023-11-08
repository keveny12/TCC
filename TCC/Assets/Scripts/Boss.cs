using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float velocidade;
    public float tempoDeAndar;
    private float timer;
    public bool andar = true;
    private Rigidbody2D rig;
    public Slider barraDeVidaDoBoss;
    public GameObject laserDoBoss;
    public GameObject laserDoBoss2;
    public Transform localDoDisparo;
    public float tempoMaximoEntreOsLasers;
    public float tempoAtualDosLasers;

    public int vidaMaximaDoInimigo;
    public int vidaAtualDoInimigo;

    //public int vidaParaTrocarTiro;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
        barraDeVidaDoBoss.maxValue = vidaMaximaDoInimigo;
        barraDeVidaDoBoss.value = vidaAtualDoInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        AtirarLaser();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= tempoDeAndar)
        {
            andar = !andar;
            timer = 0f;
        }

        if (andar)
        {
            rig.velocity = Vector2.up * velocidade;  
        }
        else
        {
            rig.velocity = Vector2.down * velocidade;
        }
        
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;
        if (tempoAtualDosLasers <= 0)
        {
            Instantiate(laserDoBoss, localDoDisparo.position, Quaternion.Euler(0f, 0f, 90f ));
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
        }
       // if (vidaAtualDoInimigo == vidaParaTrocarTiro)
       // {
           // if (tempoAtualDosLasers <= 0)
          //  {
          //      Instantiate(laserDoBoss2, localDoDisparo.position, Quaternion.Euler(0f, 0f, 90f ));
            //    tempoAtualDosLasers = tempoMaximoEntreOsLasers;
           // }
       // }
        
        
    }

    public void DanoInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;
        barraDeVidaDoBoss.value = vidaAtualDoInimigo;

        if (vidaAtualDoInimigo <= 0)
        {
            //GameManager.Instance.AumentoPontos(darPontos);
            //int numeroAleatorio = Random.Range(0, 100); //cria variavel que sortea um numero aleatorio para dropar o power up
            //if (numeroAleatorio <= chanceParaDropar) //porcentagem da chance de dropar power up
            //{
            //    Instantiate(itenParaDropar, transform.position, Quaternion.Euler(0f, 0f, 0f));
           // }
            Destroy(this.gameObject);
        }
    }
}
