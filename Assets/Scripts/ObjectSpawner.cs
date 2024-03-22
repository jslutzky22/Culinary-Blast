using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject[] fruitList;
    [SerializeField] private GameObject spawner;

    private void Start()
    {
        StartCoroutine(fruitSpawner());
    }

    private IEnumerator fruitSpawner()
    {
        while (true)
        {
            int fruitNumber = Random.Range(0, fruitList.Length);
            Instantiate(fruitList[fruitNumber].gameObject, spawner.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
