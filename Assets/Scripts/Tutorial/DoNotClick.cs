/*****************************************************************************
// File Name : DoNotClick.cs
// Author : Jake Slutzky
// Creation Date : March 19, 2024
//
// Brief Description : This script causes it so that when you click the tutorial fruit, it flashes a big X on screen
//                     and teleports it back
*****************************************************************************/
using System.Collections;
using UnityEngine;

public class DoNotClick : MonoBehaviour, IClick
{
    /// <summary>
    /// The variables
    /// </summary>
    [SerializeField] private AudioClip incorrectSound;
    [SerializeField] private AudioSource MyAudioSource;
    [SerializeField] private GameObject bigX;
    [SerializeField] private GameObject resetSpot;
    [SerializeField] private float xTurnOff;

    /// <summary>
    /// On click, start the "misfire" coroutine and set the fruit back to the reset spot to try again.
    /// </summary>
    public void onClickAction()
    {
        StartCoroutine(misfire());
        transform.position = resetSpot.transform.position;
    }

    /// <summary>
    /// On triggering, flash a big X, make a noise, and then disable it
    /// </summary>
    /// <returns></returns>
    private IEnumerator misfire()
    {
        bigX.SetActive(true);
        MyAudioSource.PlayOneShot(incorrectSound, 1.0f);
        yield return new WaitForSeconds(xTurnOff);
        bigX.SetActive(false);
    }
}
