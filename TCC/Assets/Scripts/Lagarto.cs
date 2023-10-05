using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lagarto : MonoBehaviour
{
    private Rigidbody2D rig;
    public float velocidade;
    public bool direcao;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    
    void FixedUpdate()
    {

       
            rig.velocity = Vector2.left * velocidade;
       
            
        
                
                
    }
}
