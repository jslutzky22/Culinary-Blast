/*****************************************************************************
// File Name : Fruit.cs
// Author : Jake Slutzky
// Creation Date : March 24, 2024
//
// Brief Description : This script makes it so that whenever you click the fruit object, it triggers the onClickAction
//                     which deletes this object
*****************************************************************************/
using UnityEngine;

public class Fruit : MonoBehaviour, IClick
{
    public void onClickAction()
    {
        Destroy(gameObject);
    }
}
