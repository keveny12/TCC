using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody2D;
    public float _playerVelocidade;
    private Vector2 _playerDireção;

    public GameObject tiroDoPlayer;
    public Transform localDoDisparo;
    public bool temTiroDuplo;
    public Transform Arma;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        temTiroDuplo = false;
    }

    // Update is called once per frame
    void Update()
    {
        _playerDireção = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        Atirar();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (mousePos - Arma.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Arma.localRotation = Quaternion.Euler(0,0,angle);
    }

    void FixedUpdate()
    {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDireção * _playerVelocidade * Time.fixedDeltaTime);
    }

    private void Atirar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (temTiroDuplo == false)
            {
                Instantiate(tiroDoPlayer, localDoDisparo.position, Arma.localRotation );
            }
            
        }
    }
}
