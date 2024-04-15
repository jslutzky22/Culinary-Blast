/*****************************************************************************
// File Name : Tutorial.cs
// Author : Jake Slutzky
// Creation Date : April 14, 2024
//
// Brief Description : This script causes various conversations to start.
*****************************************************************************/
using DialogueEditor;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    /// <summary>
    /// The variables
    /// </summary>
    [SerializeField] NPCConversation convo1;
    [SerializeField] NPCConversation convo2;
    [SerializeField] NPCConversation convo3;
    [SerializeField] GameObject tutorialTrash;
    [SerializeField] GameObject tutorialFruit;
    [SerializeField] GameObject leaveButton;

    /// <summary>
    /// On start, start up the first dialogue
    /// </summary>
    void Start()
    {
        ConversationManager.Instance.StartConversation(convo1);
    }

    /// <summary>
    /// These voids all causes an object to turn on when triggered or start a conversations..
    /// </summary>
    public void tutorialTrashSpawner()
    {
        tutorialTrash.SetActive(true);
    }
    public void tutorialFruitSpawner()
    {
        tutorialFruit.SetActive(true);
    }
    public void leaveButtonSpawner()
    {
        leaveButton.SetActive(true);
    }
    public void secondConversation()
    {
        ConversationManager.Instance.StartConversation(convo2);
    }
    public void thirdConversation()
    {
        ConversationManager.Instance.StartConversation(convo3);
    }
}
