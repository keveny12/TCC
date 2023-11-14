using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int danoParaDar;
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
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
        barraDeVidaDoBoss.maxValue = vidaMaximaDoInimigo;
        barraDeVidaDoBoss.value = vidaAtualDoInimigo;
    }

    
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
        
    }

    public void DanoInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;
        barraDeVidaDoBoss.value = vidaAtualDoInimigo;

        if (vidaAtualDoInimigo <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)//diz qual objeto colidiu com o jogador
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<VidaDoJogador>().DanoJogador(danoParaDar);
        }
    }

}
