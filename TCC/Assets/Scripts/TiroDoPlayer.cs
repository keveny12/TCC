using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroDoPlayer : MonoBehaviour
{
    public float velocidadeDoTiro;
    public int danoParaDar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        MovimentarTiro();
    }

    private void MovimentarTiro()
    {
        transform.Translate(Vector3.right * velocidadeDoTiro * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            col.gameObject.GetComponent<Inimigos>().DanoInimigo(danoParaDar);
            Destroy(this.gameObject);
        }
        if (col.gameObject.CompareTag("Boss"))
        {
            col.gameObject.GetComponent<Boss>().DanoInimigo(danoParaDar);
            Destroy(this.gameObject);
        }
        if (col.gameObject.CompareTag("Lagarto"))
        {
            col.gameObject.GetComponent<Lagarto>().DanoInimigo(danoParaDar);
            Destroy(this.gameObject);
        }
    }
    
}
