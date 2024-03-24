/*****************************************************************************
// File Name : ObjectSpawner.cs
// Author : Jake Slutzky
// Creation Date : March 24, 2024
//
// Brief Description : This script spawns fruits every few seconds from a list of potential fruits
*****************************************************************************/
using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    /// <summary>
    /// The variables
    /// </summary>
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject[] fruitList;
    [SerializeField] private GameObject spawner;

    /// <summary>
    /// On start, start the fruit spawner Coroutine
    /// </summary>
    private void Start()
    {
        StartCoroutine(fruitSpawner());
    }

    /// <summary>
    /// Every spawnTime seconds, spawn a fruit from the list of fruits at the current position of this gameObject
    /// </summary>
    /// <returns></returns>
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
