using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, seg;

    [SerializeField] Text tempo;

    private float restante;
    private bool andando;

    private void Awake()
    {
        restante = (min * 60) + seg;
        andando = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (andando)
        {
            restante -= Time.deltaTime;
            if (restante < 1)
            {
                andando = true;
                //soltar o boss
            }

            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
}
