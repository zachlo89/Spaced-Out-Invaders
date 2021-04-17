using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float horizInput;
    public float vertInput;
    
    void Start()
    {
        // tk curr pos and assign it as start pos
        // transform.position = new Vector3(0, 0, 0);
        transform.position = Vector3.zero;
    }
    
    void Update() // called once per fr; 60 fr/sec
    {
        PlayerMovement();
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
}