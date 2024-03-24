using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fruit : MonoBehaviour, IClick
{
    public void onClickAction()
    {
        //Debug.Log("Fruit clicking~");

        Destroy(gameObject);
    }
}
