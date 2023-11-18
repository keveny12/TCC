using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moeda : MonoBehaviour
{
    public int scorevalue;
    private AudioSource sound;

    void Awake()
    {
        sound = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sound.Play();
            GameController.instance.UpdateScore(scorevalue);
            Destroy(gameObject, 0.1f);
        }
    }

    
}
