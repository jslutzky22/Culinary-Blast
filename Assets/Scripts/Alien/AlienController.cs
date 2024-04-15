/*****************************************************************************
// File Name : AlienController.cs
// Author : Jake Slutzky
// Creation Date : April 14, 2024
//
// Brief Description : This script makes it so that if a Smoothie collides with an Alien, it beams up the alien
//                     and replaces them with an alien from a list.
*****************************************************************************/
using System.Collections;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    /// <summary>
    /// The Variables
    /// </summary>
    [SerializeField] private GameObject alienSpawnSpot;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject[] alienList;
    [SerializeField] private GameObject alienDeleter;
    [SerializeField] private GameObject beam;

    /// <summary>
    /// If trigger collision with "smoothie" tagged object, start alienSpawn coroutine
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Smoothie"))
        {
            Debug.Log("Collided");
            StartCoroutine(alienSpawn());
        }
    }

    /// <summary>
    /// Whem triggered, spawn an alien deleting beam, wait a "spawnTime", then get rid of the beam and spawn a new
    /// alien from the list.
    /// </summary>
    /// <returns></returns>
    private IEnumerator alienSpawn()
    {
        Debug.Log("spawningAlien");
        beam.SetActive(true);
        alienDeleter.SetActive(true);
        yield return new WaitForSeconds(spawnTime);
        alienDeleter.SetActive(false);
        beam.SetActive(false);
        int alienNumber = Random.Range(0, alienList.Length);
        Instantiate(alienList[alienNumber].gameObject, alienSpawnSpot.transform.position, Quaternion.identity);
    }
}
