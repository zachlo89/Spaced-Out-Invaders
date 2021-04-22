using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        StartCoroutine(SpawnRoutine());
    }
    
    // spawn game objects every 5 seconds
    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(5);
    }
}
