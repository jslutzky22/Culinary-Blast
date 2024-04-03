using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] NPCConversation convo1;
    [SerializeField] NPCConversation convo2;
    [SerializeField] NPCConversation convo3;
    //[SerializeField] NPCConversation convo4;
    [SerializeField] GameObject tutorialTrash;
    [SerializeField] GameObject tutorialFruit;
    [SerializeField] GameObject leaveButton;
    //private bool convo2Fired = false;
    //private bool convo3Fired = false;
    // Start is called before the first frame update
    void Start()
    {
        ConversationManager.Instance.StartConversation(convo1);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(convo2Fired = false && convo2.isActiveAndEnabled) 
        {
            Debug.Log("Convo2Fired");
            convo2Fired = true;
            secondConversation();
        }*/
    }

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
    /*public void tutorialFinalTrashSpawner()
    {
        tutorialFruit.SetActive(true);
    }*/
    public void secondConversation()
    {
        
            //convo2Fired = true;
            ConversationManager.Instance.StartConversation(convo2);
       
        /*if(convo3Fired == true) 
        {
            //ConversationManager.Instance.StartConversation(convo4);
            leaveButton.SetActive(true);
        }*/
    }
    public void thirdConversation()
    {
       
            //convo3Fired = true;
            ConversationManager.Instance.StartConversation(convo3);
        
        /*if(convo3Fired == true) 
        {
            //ConversationManager.Instance.StartConversation(convo4);
            leaveButton.SetActive(true);
        }*/
    }
}
