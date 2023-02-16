using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnRate;
    [SerializeField] float spawnDelay;
    [SerializeField] List<GameObject> inimigos = new List<GameObject>();

    DificuldadeType dificuldadeAtual;


    private void Start()
    {
        dificuldadeAtual = ScoreManager.instance.dificuldade;
        InvokeRepeating("SpawnRandomEnemy", spawnDelay, spawnRate);
    }

    private void Update()
    {
        if(dificuldadeAtual != ScoreManager.instance.dificuldade)
        {
            dificuldadeAtual = ScoreManager.instance.dificuldade;
            spawnRate -= 1;
            //spawnDelay -= 1;
            CancelInvoke();
            InvokeRepeating("SpawnRandomEnemy", spawnDelay, spawnRate);
        }
    }

    private void SpawnRandomEnemy()
    {
        int random = Random.Range(0, inimigos.Count);
        Vector3 spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-0.36f, 0.16f);  
        Instantiate(inimigos[random], spawnPosition, transform.rotation);
    }
}
