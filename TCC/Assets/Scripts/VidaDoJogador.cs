using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour
{
    public Slider barraDeVidaDoJogador;
    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador = 0;
    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;
    public bool temEscudo;
    public GameObject escudoDoJogador; 
    
    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;
        barraDeVidaDoJogador.maxValue = vidaMaximaDoJogador;
        barraDeVidaDoJogador.value = vidaAtualDoJogador;

        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        escudoDoJogador.SetActive(false);
        temEscudo = false;
    }
    
    void Update()
    {
        
    }

    public void AtivarEscudo()
    {
        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        escudoDoJogador.SetActive(true);
        temEscudo = true;
    }

    public void GanharVida(int vidaParaReceber)
    {
        if (vidaAtualDoJogador + vidaParaReceber <= vidaMaximaDoEscudo)
        {
            vidaAtualDoJogador += vidaParaReceber;
        }
        else
        {
            vidaAtualDoJogador = vidaMaximaDoJogador;
        }

        barraDeVidaDoJogador.value = vidaAtualDoJogador;
    }
    public void DanoJogador(int danoParaReceber)
    {
        if (temEscudo == false)
        {
            vidaAtualDoJogador -= danoParaReceber;
            barraDeVidaDoJogador.value = vidaAtualDoJogador;

            if (vidaAtualDoJogador <= 0)
            {
                GameController.instance.GameOver();
                //vidaAtualDoJogador = vidaMaximaDoJogador;
                //barraDeVidaDoJogador.value = vidaAtualDoJogador;
                //GameController.instance.TirarVida();
            }

        }
        else
        {
            vidaAtualDoEscudo -= danoParaReceber;
            if (vidaAtualDoEscudo <= 0)
            {
                escudoDoJogador.SetActive(false);
                temEscudo = false;
            }
        }
    }
}
