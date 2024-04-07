/*****************************************************************************
// File Name : Fruit.cs
// Author : Jake Slutzky
// Creation Date : March 24, 2024
//
// Brief Description : This script makes it so that whenever you click the fruit object, it triggers the onClickAction
//                     which deletes this object
*****************************************************************************/
using System.Collections;
using UnityEngine;

public class Fruit : MonoBehaviour, IClick
{
    [SerializeField] private AudioClip incorrectSound;
    [SerializeField] private AudioSource MyAudioSource;
    //[SerializeField] private GameObject bigX;
    [SerializeField] private float xTurnOff;
    public void onClickAction()
    {
        //StartCoroutine(misfire());
        Destroy(gameObject);
    }
    private IEnumerator misfire()
    {
       // bigX.SetActive(true);
        //MyAudioSource.PlayOneShot(incorrectSound, 1.0f);
        yield return new WaitForSeconds(xTurnOff);
        //bigX.SetActive(false);
    }
}
