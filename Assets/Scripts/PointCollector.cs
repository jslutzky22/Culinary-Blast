using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private int pointsTotal = 0;
    [SerializeField] private int smoothieProgress = 0;
    //int pointsFinal;

    public int PointsTotal { get => pointsTotal; set => pointsTotal = value; }

    private void Start()
    {
        _pointsText.text = "Points: " + pointsTotal.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if(collision.gameObject.CompareTag("Trash"))
        {
            pointsTotal -= 100;
            _pointsText.text = "Points: " + pointsTotal.ToString();
            Destroy(collision.gameObject);
        }*/
        /*if (collision.gameObject.CompareTag("Fruit"))
        {
            pointsTotal += 100;
            _pointsText.text = "Points: " + pointsTotal.ToString();
            Destroy(collision.gameObject);
        }*/
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

    private void Update()
    {
        if (smoothieProgress >= 5) 
        {
            pointsTotal += 300;
            _pointsText.text = "Points: " + pointsTotal.ToString();
            Debug.Log("smoothie made!");
            smoothieProgress = 0;
        }
        //pointsTotal = pointsFinal;
    }
}
