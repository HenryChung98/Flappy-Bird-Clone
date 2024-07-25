using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private AudioSource scoreSound;
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.CompareTag("Player")){
            scoreSound.Play();
            GameManager.instance.AddScore();
        }
    }
}
