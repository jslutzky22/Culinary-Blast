/*****************************************************************************
// File Name : PointCollector.cs
// Author : Jake Slutzky
// Creation Date : March 24, 2024
//
// Brief Description : This script is attached to the stand and collects points based off what tag collides with it.
//                     This script also collects and manages smoothie progress based off colliding tags.
*****************************************************************************/
//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointCollector : MonoBehaviour
{
    /// <summary>
    /// The Variables
    /// </summary>
    [SerializeField] private AudioClip squelch;
    [SerializeField] private AudioClip trashBlend;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private int pointsTotal = 0;
    [SerializeField] private int smoothieProgress = 0;
    [SerializeField] private Image smoothieBar;
    [SerializeField] private float stylePoints = 0;
    [SerializeField] private GameObject delectable;
    [SerializeField] private GameObject culinary;
    [SerializeField] private GameObject boiling;
    [SerializeField] private GameObject appetizing;
    [SerializeField] private GameObject savory;
    [SerializeField] private int styleMod;
    [SerializeField] private GameObject x2Display;
    [SerializeField] private GameObject x3Display;
    [SerializeField] private GameObject smoothie;
    [SerializeField] private GameObject smoothieSpawnLocation;
    [SerializeField] private GameObject smoothieSendLocation;
    [SerializeField] private GameObject trashTouched;
    [SerializeField] private float smoothieSpeed;
    [SerializeField] private bool isSmoothieMoving;
    [SerializeField] private GameObject normalStyleBar;
    [SerializeField] private GameObject specialStyleBar;

    /// <summary>
    /// The Getter Setters
    /// </summary>
    public int PointsTotal { get => pointsTotal; set => pointsTotal = value; }

    /// <summary>
    /// On start, update the points text to reflect the point total
    /// </summary>
    private void Start()
    {
        _pointsText.text = "$" + pointsTotal.ToString();
        smoothieBar.fillAmount = smoothieProgress / 5.0f;
        StartCoroutine(DecrementStylePoints());
    }

    /// <summary>
    /// On collision, depending on the tag, either add points and 1 smoothie progress or take away points and
    /// minus 1 smoothie progress. Also add to or take away from the amount of style points the player has.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            pointsTotal += 100 * styleMod;
            _pointsText.text = "$" + pointsTotal.ToString();
            smoothieProgress += 1;
            smoothieBar.fillAmount = smoothieProgress / 5.0f;
            stylePoints += 10;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(squelch);
        }
        if (collision.gameObject.CompareTag("Trash"))
        {
            pointsTotal -= 100;
            _pointsText.text = "$" + pointsTotal.ToString();
            smoothieProgress = 0;
            smoothieBar.fillAmount = smoothieProgress / 5.0f;
            stylePoints -= 150;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(trashBlend);
            StartCoroutine(trashCaught());
        }

    }

    /// <summary>
    /// If smoothie progress is equal to or greater then 5. Add 300 points and set smoothie progress to 0.
    /// If the player has certain amounts of style points, enable certain gameObjects and multiply the amount of points
    /// obtained.
    /// </summary>
    private void Update()
    {
        _pointsText.text = "$" + pointsTotal.ToString();
        if (smoothieProgress >= 5) 
        {
            pointsTotal += 300 * styleMod;
            _pointsText.text = "$" + pointsTotal.ToString();
            StartCoroutine(smoothieLaunch());
            smoothieProgress = 0;
            smoothieBar.fillAmount = smoothieProgress / 5.0f;
            stylePoints += 25;
        }
        if (stylePoints < 0)
        {
            stylePoints = 0;
        }
        if (stylePoints <= 29)
        {
            delectable.SetActive(false);
            culinary.SetActive(false);
            boiling.SetActive(false);
            appetizing.SetActive(false);
            savory.SetActive(false);

            x2Display.SetActive(false);
            x3Display.SetActive(false);
            styleMod = 1;
            normalStyleBar.SetActive(false);
            specialStyleBar.SetActive(false);
        }
        if (stylePoints >= 30 && stylePoints < 70)
        {
            delectable.SetActive(true);
            culinary.SetActive(false);
            boiling.SetActive(false);
            appetizing.SetActive(false);
            savory.SetActive(false);

            x2Display.SetActive(false);
            x3Display.SetActive(false);
            styleMod = 1;
            normalStyleBar.SetActive(true);
            specialStyleBar.SetActive(false);
        }
        if (stylePoints >= 71 && stylePoints < 130)
        {
            delectable.SetActive(false);
            culinary.SetActive(true);
            boiling.SetActive(false);
            appetizing.SetActive(false);
            savory.SetActive(false);

            x2Display.SetActive(false);
            x3Display.SetActive(false);
            styleMod = 1;
            normalStyleBar.SetActive(true);
            specialStyleBar.SetActive(false);
        }
        if (stylePoints >= 131 && stylePoints < 170)
        {
            delectable.SetActive(false);
            culinary.SetActive(false);
            boiling.SetActive(true);
            appetizing.SetActive(false);
            savory.SetActive(false);

            x2Display.SetActive(true);
            x3Display.SetActive(false);
            styleMod = 2;
            normalStyleBar.SetActive(false);
            specialStyleBar.SetActive(true);
        }
        if (stylePoints >= 171 && stylePoints < 230)
        {
            delectable.SetActive(false);
            culinary.SetActive(false);
            boiling.SetActive(false);
            appetizing.SetActive(true);
            savory.SetActive(false);

            x2Display.SetActive(true);
            x3Display.SetActive(false);
            styleMod = 2;
            normalStyleBar.SetActive(false);
            specialStyleBar.SetActive(true);
        }
        if (stylePoints >= 231)
        {
            delectable.SetActive(false);
            culinary.SetActive(false);
            boiling.SetActive(false);
            appetizing.SetActive(false);
            savory.SetActive(true);

            x2Display.SetActive(false);
            x3Display.SetActive(true);
            styleMod = 3;
            normalStyleBar.SetActive(false);
            specialStyleBar.SetActive(true);
        }
        if (stylePoints > 260)
        {
            stylePoints = 260;
        }
    }

    /// <summary>
    /// When smoothieLaunch is triggered, launch a smoothie on a path towards the smoothieSendLocation. Then hide it
    /// once the smoothie is close enough
    /// </summary>
    /// <returns></returns>
    private IEnumerator smoothieLaunch()
    {
        smoothie.transform.position = smoothieSpawnLocation.transform.position;
        smoothie.SetActive(true);
        isSmoothieMoving = true;
        while (isSmoothieMoving)
        {
            Vector3 direction = (smoothieSendLocation.transform.position - smoothie.transform.position).normalized;
            smoothie.transform.Translate(direction * smoothieSpeed * Time.deltaTime);

            if (Vector3.Distance(smoothie.transform.position, smoothieSendLocation.transform.position) < 0.1f)
            {
                isSmoothieMoving = false;
                smoothie.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }

    /// <summary>
    /// Every second, remove 2 from stylePoints.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DecrementStylePoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            stylePoints -= 2;
        }
    }
    private IEnumerator trashCaught() 
    {
        trashTouched.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        trashTouched.SetActive(false);
    }
}
