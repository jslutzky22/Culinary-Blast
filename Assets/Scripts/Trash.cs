using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IClick
{
    public void onClickAction()
    {
        Debug.Log("Trash Blasting");

        Destroy(gameObject);
    }
}
