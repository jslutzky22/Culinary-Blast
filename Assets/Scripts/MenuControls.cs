/*****************************************************************************
// File Name : MenuControls.cs
// Author : Jake Slutzky
// Creation Date : March 18, 2024
//
// Brief Description : This script controls the main menu and allows the player to press the quit, start, 
                       and other menu buttons.
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    [SerializeField] GameObject _controlsPanel;
    [SerializeField] GameObject _creditsPanel;
    [SerializeField] GameObject _startButton;
    [SerializeField] GameObject _controlsButton;
    [SerializeField] GameObject _creditsButton;
    [SerializeField] GameObject _quitButton;

    /// <summary>
    /// When this void is triggered, the game will load the next scene
    /// Eventually it will also trigger a menu transition of some sort prior to the next scene loading
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// When this void is triggered, the game will close itself
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// when this void is triggered, the game will load the "Menu" scene
    /// </summary>
    public void Scene1()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// When this void is trigged, it will Open the controls panel
    /// </summary>
    public void OpenControls()
    {
        _controlsPanel.SetActive(true);
        //_closeControlsButton.SetActive(true);
        _startButton.SetActive(false);
        _controlsButton.SetActive(false);
        _creditsButton.SetActive(false);
        _quitButton.SetActive(false);
    }

    /// <summary>
    /// When this void is trigged, it will Close the controls panel
    /// </summary>
    public void CloseControls()
    {
        _controlsPanel.SetActive(false);
        //_closeControlsButton.SetActive(false);
        _startButton.SetActive(true);
        _controlsButton.SetActive(true);
        _creditsButton.SetActive(true);
        _quitButton.SetActive(true);
    }

    /// <summary>
    /// When this void is trigged, it will Open the credits panel
    /// </summary>
    public void OpenCredits()
    {
        _creditsPanel.SetActive(true);
        //_closeCreditsButton.SetActive(true);
        _startButton.SetActive(false);
        _controlsButton.SetActive(false);
        _creditsButton.SetActive(false);
        _quitButton.SetActive(false);
    }

    /// <summary>
    /// When this void is trigged, it will Close the credit panel
    /// </summary>
    public void CloseCredits()
    {
        _creditsPanel.SetActive(false);
        //_closeCreditsButton.SetActive(false);
        _startButton.SetActive(true);
        _controlsButton.SetActive(true);
        _creditsButton.SetActive(true);
        _quitButton.SetActive(true);
    }
}
