using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _speed = 5;
    [SerializeField] private GameObject _laserPrefab;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        
        if (transform.position.y <= -5.8f)
        {
            // respawn at top of screen w/ a new random x pos
            transform.position = new Vector3((Random.Range(-9, 9)), 8, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player _player = other.transform.GetComponent<Player>();

            if (_player != null)
            {
                _player.DamageTaken();
            }
            
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
