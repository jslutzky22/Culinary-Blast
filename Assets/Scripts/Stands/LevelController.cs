/*****************************************************************************
// File Name : LevelController.cs
// Author : Jake Slutzky
// Creation Date : March 24, 2024
//
// Brief Description : This scripts controls the level time, time it takes to win, and all UI that occurs on the end.
*****************************************************************************/
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    /// <summary>
    /// The variables
    /// </summary>
    [SerializeField] private AudioClip bloop;
    [SerializeField] private AudioClip megaBloop;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject stand1;
    [SerializeField] private GameObject styleRanks;
    [SerializeField] private GameObject winHud;
    [SerializeField] private float remainingTime;
    [SerializeField] private GameObject originalPointsText;
    [SerializeField] private TMP_Text _finalPointsText;
    [SerializeField] private TMP_Text _TimerText;
    [SerializeField] private int finalPoints;
    [SerializeField] private int star1Points;
    [SerializeField] private int star2Points;
    [SerializeField] private int star3Points;
    private PointCollector pointCollector;
    [SerializeField] private GameObject emptyStar1;
    [SerializeField] private GameObject emptyStar2;
    [SerializeField] private GameObject emptyStar3;
    [SerializeField] private GameObject fullStar1;
    [SerializeField] private GameObject fullStar2;
    [SerializeField] private GameObject fullStar3;
    //[SerializeField] private bool level1;
    //[SerializeField] private bool level2;
    //[SerializeField] private bool level3;
    //[SerializeField] private bool level4;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject _timerText;
    [SerializeField] private GameObject smoothieMeter;
    private bool levelCompleted = false;
    private bool starsCouroutineShot;

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
            stand1.SetActive(false);
            winHud.SetActive(true);
            _timerText.SetActive(false);
            styleRanks.SetActive(false);
            smoothieMeter.SetActive(false);
            
            _finalPointsText.text = "Paycheck: $" + pointCollector.PointsTotal.ToString();
            if (starsCouroutineShot == false)
            {
                StartCoroutine(starCouroutine());
                starsCouroutineShot = true;
            }

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

    /// <summary>
    /// On the IEnumerator being triggered. Spawn empty stars, wait a second, and then depending on your final
    /// points, fill in stars to showcase how well the player did
    /// </summary>
    /// <returns></returns>
    private IEnumerator starCouroutine()
    {
      emptyStar1.SetActive(true);
      emptyStar2.SetActive(true);
      emptyStar3.SetActive(true);
        yield return new WaitForSeconds(1f);
        if (pointCollector.PointsTotal >= star1Points)
        {
            audioSource.PlayOneShot(bloop, 0.5f);
            fullStar1.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        if (pointCollector.PointsTotal >= star2Points)
        {
            audioSource.PlayOneShot(bloop, 0.5f);
            fullStar2.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        if (pointCollector.PointsTotal >= star3Points)
        {
            audioSource.PlayOneShot(megaBloop, 0.5f);
            fullStar3.SetActive(true);
        }
    }
}
