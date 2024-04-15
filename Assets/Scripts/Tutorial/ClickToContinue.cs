/*****************************************************************************
// File Name : ClickToContinue.cs
// Author : Jake Slutzky
// Creation Date : April 14, 2024
//
// Brief Description : This script is used to spawn certain objects when clicked
*****************************************************************************/
using UnityEngine;

public class ClickToContinue : MonoBehaviour, IClick
{
    /// <summary>
    /// The Variables
    /// </summary>
    [SerializeField] private GameObject currentDialogue;
    [SerializeField] private GameObject nextDialogue;
    [SerializeField] private Tutorial tutorial;

    /// <summary>
    /// This script causes it to enable the "nextDialogue" object and turn off the "currentDialogue" When clicked. 
    /// It also causes the "secondConversation" void in the tutorial script before destroying this object.
    /// </summary>
    public void onClickAction()
    {
        currentDialogue.SetActive(false);
        nextDialogue.SetActive(true);
        tutorial.secondConversation();
        Destroy(gameObject);
    }
}
