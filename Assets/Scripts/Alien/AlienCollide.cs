/*****************************************************************************
// File Name : AlienCollide.cs
// Author : Jake Slutzky
// Creation Date : April 14, 2024
//
// Brief Description : This script causes the attached object to delete when it touches a "Deleter" trigger
*****************************************************************************/
using UnityEngine;

public class AlienCollide : MonoBehaviour
{
    /// <summary>
    /// If the object collides with a "Deleter" object. Destroy this object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Deleter"))
        {
            Destroy(gameObject);
        }
    }
}
