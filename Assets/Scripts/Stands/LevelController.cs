/*****************************************************************************
// File Name : LevelController.cs
// Author : Jake Slutzky
// Creation Date : March 24, 2024
//
// Brief Description : This scripts controls the level time, time it takes to win, and all UI that occurs on the end.
*****************************************************************************/
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    /// <summary>
    /// The variables
    /// </summary>
    [SerializeField] private GameObject stand1;
    [SerializeField] private GameObject stand2;
    [SerializeField] private GameObject stand3;
    [SerializeField] private GameObject stand4;
    [SerializeField] private GameObject winHud;
    [SerializeField] private float remainingTime;
    [SerializeField] private GameObject originalPointsText;
    [SerializeField] private TMP_Text _finalPointsText;
    [SerializeField] private TMP_Text _TimerText;
    [SerializeField] private int finalPoints;
    private PointCollector pointCollector;
    [SerializeField] private bool level1;
    [SerializeField] private bool level2;
    [SerializeField] private bool level3;
    [SerializeField] private bool level4;
    [SerializeField] private GameObject pauseMenu;
    private bool levelCompleted = false;

    /// <summary>
    /// On start, find the pointCollector object and ensure the winHud is off
    /// </summary>
    void Start()
    {
        pointCollector = FindObjectOfType<PointCollector>();
        winHud.SetActive(false);
    }

    /// <summary>
    /// Every frame, check if the countdown timer is 0. Otherwise, minus it by the current time. If it is 0, set itself
    /// to 0 every frame, turn it red, and trigger the end conditions of turning off all the menus and enabling the
    /// end menu.
    /// </summary>
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        if (remainingTime < 0)
        {
            remainingTime = 0;
            //GameOver(); TO DO! Add a big bold effect when timer hits 0
            _TimerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        _TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (remainingTime == 0 && !levelCompleted)
        {
            pauseMenu.SetActive(false);
            originalPointsText.SetActive(false);
          if (level1 == true)
            {
                stand1.SetActive(false);
            }
          if (level2 == true)
            {
                stand1.SetActive(false);
                stand2.SetActive(false);
            }
          if (level3 == true)
            {
                stand1.SetActive(false);
                stand2.SetActive(false);
                stand3.SetActive(false);
            }
          if (level4 == true)
            {
                stand1.SetActive(false);
                stand2.SetActive(false);
                stand3.SetActive(false);
                stand4.SetActive(false);
            }
           
            winHud.SetActive(true);

            
            _finalPointsText.text = "Final Points: " + pointCollector.PointsTotal.ToString();
           

            
            levelCompleted = true;
        }
    }

    /// <summary>
    /// On ToMenu triggered, load the Menu scene
    /// </summary>
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// On NextLevel triggered, turn off the winHud and load the next scene in the scene order
    /// </summary>
    public void NextLevel()
    {
        winHud.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// On OpenPause triggered, turn on the pause menu HUD.
    /// </summary>
    public void OpenPause()
    {
        pauseMenu.SetActive(true);
    }

    /// <summary>
    /// On ClosePause triggered, turn off the pause menu HUD.
    /// </summary>
    public void ClosePause()
    {
        pauseMenu.SetActive(false);
    }
}
