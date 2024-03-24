using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IClick
{
    private PointCollector pointCollector;
    private void Start()
    {
        pointCollector = FindObjectOfType<PointCollector>();
    }
    public void onClickAction()
    {
        //Debug.Log("Trash Blasting");
        pointCollector.PointsTotal += 100;
        Destroy(gameObject);
    }
}
