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
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        
        // transform.Translate(new Vector3(1, 0, 0) * _speed * realTime); // 1m to right at 60m/sec
        // transform.Translate(Vector3.right * horizInput * _speed *Time.deltaTime);
        // transform.Translate(Vector3.up * vertInput * _speed * Time.deltaTime);

        Vector3 direction = new Vector3(horizInput, vertInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        // if player pos on y is > 0 
        // y pos = 0
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z); // get curr x and z values y is 0
        }
    }
}