using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool itemDeEscudo;
    public bool itemDeVida;
    public bool itemDePocao;
    public bool itemDeTiroDuplo;
    public int vidaParaDar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (itemDeEscudo == true)
            {
                other.gameObject.GetComponent<VidaDoJogador>().AtivarEscudo();
            }

            if (itemDePocao == true)
            {
                other.gameObject.GetComponent<PlayerController>().temPocao = false;
                other.gameObject.GetComponent<PlayerController>().tempoAtualDaPocao =
                    other.gameObject.GetComponent<PlayerController>().tempoMaximoDaPocao;
                other.gameObject.GetComponent<PlayerController>().temPocao = true;
            }

            if (itemDeVida == true)
            {
                other.gameObject.GetComponent<VidaDoJogador>().GanharVida(vidaParaDar);
            }

            if (itemDeTiroDuplo == true)
            {
                other.gameObject.GetComponent<PlayerController>().temTiroDuplo = false;
                other.gameObject.GetComponent<PlayerController>().tempoAtualDosTirorsDuplos =
                    other.gameObject.GetComponent<PlayerController>().tempoMaximoDosTirosDuplus;
                other.gameObject.GetComponent<PlayerController>().temTiroDuplo = true;
            }
            
            Destroy(this.gameObject);
        }
    }
}
