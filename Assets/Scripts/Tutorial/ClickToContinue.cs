using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToContinue : MonoBehaviour, IClick
{
    [SerializeField] private GameObject currentDialogue;
    [SerializeField] private GameObject nextDialogue;
    [SerializeField] private Tutorial tutorial;
    //[SerializeField] private bool fruit;
    public void onClickAction()
    {
        currentDialogue.SetActive(false);
        nextDialogue.SetActive(true);
        tutorial.secondConversation();
        Destroy(gameObject);
    }
}
