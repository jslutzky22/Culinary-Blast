/*****************************************************************************
// File Name : LoadNextScene.cs
// Author : Jake Slutzky
// Creation Date : March 24, 2024
//
// Brief Description : This script makes it so that after loadSceneAfter seconds, it will load the next scene. This is
//                     used for cutscenes.
*****************************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    /// <summary>
    /// The variables
    /// </summary>
    [SerializeField] private float loadSceneAfter;
    private bool sceneLoadStarted = false;
    [SerializeField] private bool loadMenu;

   /// <summary>
   /// Every frame check if the scene load has been started, then depending on if loadMenu is true or not.
   /// Activate the associated following Coroutine after this.
   /// </summary>
    void Update()
    {
        if (!sceneLoadStarted && loadMenu == false)
        {
            sceneLoadStarted = true;
            StartCoroutine(loadScene());
        }
        if (!sceneLoadStarted && loadMenu == true)
        {
            sceneLoadStarted = true;
            StartCoroutine(loadMenuScene());
        }
    }

    /// <summary>
    /// After loadSceneAfter seconds, load the next scene in the build order.
    /// </summary>
    /// <returns></returns>
    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(loadSceneAfter);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// After loadSceneAfter seconds, load the menu scene.
    /// </summary>
    /// <returns></returns>
    private IEnumerator loadMenuScene()
    {
        yield return new WaitForSeconds(loadSceneAfter);
        SceneManager.LoadScene("Menu");
    }


}
