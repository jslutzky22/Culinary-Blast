using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private int pointsTotal = 0;

    private void Start()
    {
        _pointsText.text = "Points: " + pointsTotal.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Trash"))
        {
            pointsTotal -= 100;
            _pointsText.text = "Points: " + pointsTotal.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Fruit"))
        {
            pointsTotal += 100;
            _pointsText.text = "Points: " + pointsTotal.ToString();
            Destroy(collision.gameObject);
        }

    }
}
