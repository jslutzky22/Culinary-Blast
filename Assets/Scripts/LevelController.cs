using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject stand1;
    [SerializeField] private GameObject stand2;
    [SerializeField] private GameObject stand3;
    [SerializeField] private GameObject stand4;
    [SerializeField] private GameObject winHud;
    [SerializeField] private float levelTime;
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

    // Start is called before the first frame update
    void Start()
    {
        pointCollector = FindObjectOfType<PointCollector>();
        winHud.SetActive(false);
        levelTime = remainingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        if (remainingTime < 0)
        {
            remainingTime = 0;
            //GameOver(); Add a big bold effect when timer hits 0
            _TimerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        _TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //_TimerText.text -= Time.deltaTime;
        if (Time.time >= levelTime && !levelCompleted)
        {
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
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OpenPause()
    {
        pauseMenu.SetActive(true);
    }
    public void ClosePause()
    {
        pauseMenu.SetActive(false);
    }
}
