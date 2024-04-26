using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawnManager : MonoBehaviour
{
    [SerializeField] private MoneyCoin coinPrefab;
    [Space]
    [SerializeField] private float maxWidth;
    [SerializeField] private float minWidth;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [Space]
    [SerializeField] private float cooldownTimer;

    private void Start()
    {
        if (coinPrefab == null) return;
        InvokeRepeating("SpawnCoin", cooldownTimer, cooldownTimer);
    }

    private void SpawnCoin()
    {
        Vector2 placeToSpawn = new Vector2(Random.Range(minWidth,maxWidth), Random.Range(minHeight,maxHeight));
        Instantiate(coinPrefab,placeToSpawn,Quaternion.identity);
    }
}
