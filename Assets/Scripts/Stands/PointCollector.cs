/*****************************************************************************
// File Name : PointCollector.cs
// Author : Jake Slutzky
// Creation Date : March 24, 2024
//
// Brief Description : This script is attached to the stand and collects points based off what tag collides with it.
//                     This script also collects and manages smoothie progress based off colliding tags.
*****************************************************************************/
using TMPro;
using UnityEngine;

public class PointCollector : MonoBehaviour
{
    /// <summary>
    /// The Variables
    /// </summary>
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private int pointsTotal = 0;
    [SerializeField] private int smoothieProgress = 0;

    /// <summary>
    /// The Getter Setters
    /// </summary>
    public int PointsTotal { get => pointsTotal; set => pointsTotal = value; }

    /// <summary>
    /// On start, update the points text to reflect the point total
    /// </summary>
    private void Start()
    {
        _pointsText.text = "Points: " + pointsTotal.ToString();
    }

    /// <summary>
    /// On collision, depending on the tag, either add 100 points and 1 smoothie progress or take away 100 points and
    /// minus 1 smoothie progress.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            pointsTotal += 100;
            _pointsText.text = "Points: " + pointsTotal.ToString();
            smoothieProgress += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Trash"))
        {
            pointsTotal -= 100;
            _pointsText.text = "Points: " + pointsTotal.ToString();
            smoothieProgress -= 1;
            Destroy(collision.gameObject);
        }

    }

    /// <summary>
    /// If smoothie progress is equal to or greater then 5. Add 300 points and set smoothie progress to 0
    /// </summary>
    private void Update()
    {
        if (smoothieProgress >= 5) 
        {
            pointsTotal += 300;
            _pointsText.text = "Points: " + pointsTotal.ToString();
            Debug.Log("smoothie made!");
            smoothieProgress = 0;
        }
    }
}
