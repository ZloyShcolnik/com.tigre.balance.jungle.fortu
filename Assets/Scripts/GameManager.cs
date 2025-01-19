using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
  public event Action LevelLost4;
  
  public float FruitMass { get; set; }
  public List<GameObject> Fruits { get; set; }

  public ScoreView ScoreView;
  public static GameManager Instance;
  public GameObject fruitPrefab;
  public Transform spawnPoint;
  public Transform platform;
  public float fruitSpawnInterval = 2f;


  private void Awake()
  {
    Fruits = new List<GameObject>();
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }

  public void StartSpawnFruit()
  {
    InvokeRepeating(nameof(SpawnFruit), 1f, fruitSpawnInterval);
  }


  public void CancelFruitSpawn()
  {
    for (var i = Fruits.Count - 1; i >= 0; i--) Destroy(Fruits[i].gameObject);

    CancelInvoke(nameof(SpawnFruit));
  }

  public void GameOver()
  {
    LevelLost4?.Invoke();
    CancelInvoke(nameof(SpawnFruit));
  }

  private void SpawnFruit()
  {
    Vector3 spawnPosition = spawnPoint.position;
    spawnPosition.x += Random.Range(-1.8f, 1.8f);
    Fruit fruit = Instantiate(fruitPrefab, spawnPosition, Quaternion.identity).GetComponent<Fruit>();
    fruit.Init4(FruitMass);
  }
}