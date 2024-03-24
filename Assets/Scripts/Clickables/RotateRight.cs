/*****************************************************************************
// File Name : RotateRight.cs
// Author : Jake Slutzky
// Creation Date : March 24, 2024
//
// Brief Description : This script makes it so that whenever the object with this script is clicked, the player object
                       is rotated to the right 90 degrees.
*****************************************************************************/
using UnityEngine;

public class RotateRight : MonoBehaviour, IClick
{
    [SerializeField] GameObject player;
    public void onClickAction()
    {
        player.transform.Rotate(Vector3.up, 90f);
    }
}
