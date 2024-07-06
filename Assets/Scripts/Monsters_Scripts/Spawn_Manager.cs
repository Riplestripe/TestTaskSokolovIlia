
using System.Collections;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject[] spawnPrefab;
    public float radius = 8;
    Vector3 spawnPos;
    [SerializeField] int number;
    [SerializeField] int count;
    
    private void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
       
            RandomPos();
            Instantiate(spawnPrefab[Random.Range(0, spawnPrefab.Length)], spawnPos, Quaternion.identity);
            if(count != number) 
            {
            yield return ++count;
            StartCoroutine(SpawnMonsters());
            }
            else StopAllCoroutines();
    }

    private void RandomPos()
    {
        spawnPos = Random.insideUnitCircle * radius;
    }
    
}
