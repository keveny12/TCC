using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Pedra : MonoBehaviour
{
    public float velocidade;
    private Rigidbody2D rig;
    public bool direcao = true;
    public int danoParaDar;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (direcao)
        {
            rig.velocity = Vector2.up * velocidade;
        }
        else
        {
            rig.velocity = Vector2.down * velocidade;
        }
        
    }
    private void MovimentoInimigo()
    {
       
        
    }
    void OnTriggerEnter2D(Collider2D other)//diz qual objeto colidiu com o jogador
    {
       // Debug.Log(other.gameObject.tag);
       // if (other.gameObject.CompareTag("TileMap"))
        //{
          //  direcao = !direcao;
       // }
      // if (other.gameObject.CompareTag("Player"))
        //{
            //other.gameObject.GetComponent<VidaDoJogador>().DanoJogador(danoParaDar);
           // other.gameObject.GetComponent<VidaDoJogador>();
          //  Destroy(this.gameObject);
       // }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("TileMap"))
        {
            direcao = !direcao;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<VidaDoJogador>().DanoJogador(danoParaDar);
           // other.gameObject.GetComponent<VidaDoJogador>();
         //   Destroy(this.gameObject);
        }
    }
    //void OnCollisionEnter2D(Collider2D other)//diz qual objeto colidiu com o jogador
    //{
       // if (other.gameObject.CompareTag("Player"))
       // {
         //   other.gameObject.GetComponent<VidaDoJogador>().DanoJogador(danoParaDar);
            //other.gameObject.GetComponent<VidaDoJogador>();
            //Destroy(this.gameObject);
       // }
    //}
}
