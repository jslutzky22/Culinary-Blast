using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    [SerializeField] private GameObject alienSpawnSpot;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject[] alienList;
    [SerializeField] private GameObject alienDeleter;
    [SerializeField] private GameObject beam;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(alienSpawn());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Smoothie"))
        {
            Debug.Log("Collided");
            StartCoroutine(alienSpawn());

        }
    }
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
        /*GameObject newAlien = Instantiate(alienList[alienNumber].gameObject, alienSpawnSpot.transform.position, 
            Quaternion.identity) as GameObject;*/

    }
}
