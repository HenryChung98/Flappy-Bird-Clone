using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSound : MonoBehaviour
{
    [SerializeField] private AudioSource hitSound;
    
    private void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.CompareTag("Player")){
            hitSound.Play();
        }
    }
}
