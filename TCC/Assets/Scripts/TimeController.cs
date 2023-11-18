using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public GameObject boss;
    public GameObject spawn;
    private float restante;
    private bool andando;
    [SerializeField] int min, seg;
    [SerializeField] Text tempo;
    private void Awake()
    {
        restante = (min * 60) + seg;
        andando = true;
        
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (andando)
        {
            restante -= Time.deltaTime;
            if (restante <= 0)
            {
                
                ChamarBoss();
                GameController.instance.BarraDeVida();
                //soltar o boss
                andando = false;
               
                tempo.text = "00:00";
            }

            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
            
        }

       
    }
    public void ChamarBoss()
    {
        
        
            spawn = GameObject.FindWithTag("spawnBoss");
            Vector2 posicao = this.spawn.transform.position;
            GameObject bossInstance = Instantiate(boss, posicao, Quaternion.identity);
            //bossInstance.GetComponent<Boss>().barraDeVidaDoBoss = //variavel que guarda a ref pra barra de vida
        
    }
}
