/*****************************************************************************
// File Name : Trash.cs
// Author : Jake Slutzky
// Creation Date : March 19, 2024
//
// Brief Description : This scripts causes the trash objects to be destroyed when clicked and add to the total points.
*****************************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotClick : MonoBehaviour, IClick
{
    [SerializeField] private AudioClip incorrectSound;
    [SerializeField] private AudioSource MyAudioSource;
    [SerializeField] private GameObject bigX;
    [SerializeField] private GameObject resetSpot;
    [SerializeField] private float xTurnOff;
    public void onClickAction()
    {
        //ADD BIG X
        StartCoroutine(misfire());
        transform.position = resetSpot.transform.position;
        //Destroy(gameObject);
    }
    private IEnumerator misfire()
    {
        bigX.SetActive(true);
        MyAudioSource.PlayOneShot(incorrectSound, 1.0f);
        yield return new WaitForSeconds(xTurnOff);
        bigX.SetActive(false);
    }
}
