using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinho : MonoBehaviour
{
    public bool espinho;
    public int danoParaDar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }private void OnTriggerEnter2D(Collider2D other)//diz qual objeto colidiu com o jogador
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<VidaDoJogador>().DanoJogador(danoParaDar);
        }
        
        if (espinho == true)
        {
            //other.gameObject.GetComponent<PlayerController>().temEspinho = false;
            other.gameObject.GetComponent<PlayerController>().tempoAtualDoEspinho =
                other.gameObject.GetComponent<PlayerController>().tempoMaximoDoEspinho;
            other.gameObject.GetComponent<PlayerController>().temEspinho = true;
        }
    }
}
