/*****************************************************************************
// File Name : RotateLeft.cs
// Author : Jake Slutzky
// Creation Date : March 19, 2024
//
// Brief Description : This script makes it so that whenever the object with this script is clicked, the player object
                       is rotated to the left 90 degrees.
*****************************************************************************/
using UnityEngine;

public class RotateLeft : MonoBehaviour, IClick
{
    [SerializeField] GameObject player;
    public void onClickAction()
    {
        player.transform.Rotate(Vector3.up, -90f);
    }
}
