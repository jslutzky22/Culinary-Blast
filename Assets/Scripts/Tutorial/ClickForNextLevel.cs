/*****************************************************************************
// File Name : ClickForNextLevel.cs
// Author : Jake Slutzky
// Creation Date : April 14, 2024
//
// Brief Description : This script causes the player to go to the next level when click.
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickForNextLevel : MonoBehaviour, IClick
{

    /// <summary>
    /// On click, teleport the player to the next scene
    /// </summary>
    public void onClickAction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
