using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    private Transform Target;
    public float VelocidadeDoInimigo;
    public int vidaMaximaDoInimigo;
    public int vidaAtualDoInimigo;
    public int darPontos;
    public int chanceParaDropar;
    public bool temEscudo;
    public GameObject escudoDoInimigo;
    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;
    public GameObject itenParaDropar;
    public bool inimigoAtirador;

    // Start is called before the first frame update
    void Start()
    {
       
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    // Update is called once per frame
    void Update()
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
    private void MovimentoInimigo()
    {
        transform.Translate(Vector3.up * VelocidadeDoInimigo * Time.deltaTime);
        
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
                    Instantiate(itenParaDropar, transform.position, Quaternion.Euler(0f, 0f, 0f));
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
