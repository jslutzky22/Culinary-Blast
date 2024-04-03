using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStand : MonoBehaviour
{
    [SerializeField] private GameObject nextDialogue;
    [SerializeField] private GameObject currentDialogue;
    [SerializeField] private Tutorial tutorial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
