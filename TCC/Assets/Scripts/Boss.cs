using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject laserDoBoss;
    public Transform localDoDisparo;
    public float tempoMaximoEntreOsLasers;
    public float tempoAtualDosLasers;

    public int vidaMaximaDoInimigo;
    public int vidaAtualDoInimigo;
    // Start is called before the first frame update
    void Start()
    {
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        AtirarLaser();
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