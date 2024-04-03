using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    [SerializeField] NPCConversation myConversation;
    [SerializeField] GameObject tutorialTrash;

    private void Start()
    {
        ConversationManager.Instance.StartConversation(myConversation);
    }

    public void spawnTrash()
    {
        tutorialTrash.SetActive(true);
    }
}
