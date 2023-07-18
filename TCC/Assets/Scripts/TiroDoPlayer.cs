using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroDoPlayer : MonoBehaviour
{
    public float velocidadeDoTiro;
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
        transform.Translate(Vector3.up * velocidadeDoTiro * Time.deltaTime);
    }
}
