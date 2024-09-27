using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject pipes;
    private float maxY = 2.8f;
    private float minY = -2.6f;
    
    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe(){
        while (true){
            float spawnY = Random.Range(minY, maxY);

            Instantiate(pipes, new Vector3(transform.position.x, spawnY, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
}
