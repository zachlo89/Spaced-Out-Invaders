using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizInput;
    private float vertInput;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _laserOffsetAmt = 0.9f;
    [SerializeField] private float _fireRate = 0.15f;
    [SerializeField] private float _canFire = 0.0f;
    [SerializeField] private int _lives = 3;
    
    
    void Start()
    {
        // transform.position = new Vector3(0, 0, 0);
        transform.position = Vector3.zero;
    }

    void Update() // called once per fr; 60 fr/sec
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            ShootLaser();
        }
    }     

    void PlayerMovement()
    {
        float horizInput = Input.GetAxisRaw("Horizontal");
        float vertInput = Input.GetAxisRaw("Vertical");

        // transform.Translate(new Vector3(1, 0, 0) * _speed * realTime); // 1m to right at 60m/sec
        // transform.Translate(Vector3.right * horizInput * _speed *Time.deltaTime);
        // transform.Translate(Vector3.up * vertInput * _speed * Time.deltaTime);

        Vector3 direction = new Vector3(horizInput, vertInput, 0);
        
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 0), 0);

        if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
        else if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
    }

    void ShootLaser()
    {
        Vector3 _laserOffset = new Vector3(0, _laserOffsetAmt, 0);

        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + _laserOffset, Quaternion.identity);
    }

    public void DamageTaken()
    {
        _lives -= 1;
        
        if (_lives < 1)
        {
            // comm w/ spawn manager to stop spawning
            Destroy(this.gameObject);
        }
    }
}