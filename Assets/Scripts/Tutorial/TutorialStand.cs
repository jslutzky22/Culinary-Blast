/*****************************************************************************
// File Name : TutorialStand.cs
// Author : Jake Slutzky
// Creation Date : April 14, 2024
//
// Brief Description : This script is attached to the tutorial stand and ensures that if a fruit touches it, the next
//                     dialogue triggers.
*****************************************************************************/
using UnityEngine;

public class TutorialStand : MonoBehaviour
{
    [SerializeField] private GameObject nextDialogue;
    [SerializeField] private GameObject currentDialogue;
    [SerializeField] private Tutorial tutorial;
    
    /// <summary>
    /// If collision with a fruit, get rid of the current dialogue, spawn the next dialogue, and destroy the fruit
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            currentDialogue.SetActive(false);
            nextDialogue.SetActive(true);
            tutorial.thirdConversation();
            Destroy(collision.gameObject);
        }
    }
}
