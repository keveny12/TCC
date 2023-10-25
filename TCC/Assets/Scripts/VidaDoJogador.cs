using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour
{
    public Slider barraDeVidaDoJogador;//variavel para asessar barra de vida pelo slider
    
    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador = 0;
    
    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;
    public bool temEscudo;
    public GameObject escudoDoJogador; 
    // Start is called before the first frame update
    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;//sempre que o jogo iniciar a vida atual sera igual a vida maxima
        barraDeVidaDoJogador.maxValue = vidaMaximaDoJogador;// quando o jogo inicia o valor maximo da barra vai ser igual ao valor maximo da vida do jogador
        barraDeVidaDoJogador.value = vidaAtualDoJogador;

        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        escudoDoJogador.SetActive(false);
        temEscudo = false;
    }

    // Update is called once per frame
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

            if (vidaAtualDoJogador <= 0)//sempre que o jogador morrer vai rodar esse codigo
            {
                Debug.Log("perdeu hp");
                vidaAtualDoJogador = vidaMaximaDoJogador;
                barraDeVidaDoJogador.value = vidaAtualDoJogador;
                //GameController.instance.TirarVida();
            }

        }
        else
        {
            vidaAtualDoEscudo -= danoParaReceber;
            if (vidaAtualDoEscudo <= 0)
            {
                escudoDoJogador.SetActive(false);//desativa o escudo
                temEscudo = false;
            }
        }
    }
}
