using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.CompareTag("Player")){
            GameManager.instance.AddScore();
        }
    }
}
