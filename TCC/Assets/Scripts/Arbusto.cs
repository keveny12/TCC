using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbusto : MonoBehaviour
{
    public int danoParaDar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)//diz qual objeto colidiu com o jogador
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<VidaDoJogador>().DanoJogador(danoParaDar);
            other.gameObject.GetComponent<VidaDoJogador>();
            
        }
    }
}
