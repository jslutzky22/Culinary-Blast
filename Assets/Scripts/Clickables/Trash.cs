/*****************************************************************************
// File Name : Trash.cs
// Author : Jake Slutzky
// Creation Date : March 19, 2024
//
// Brief Description : This scripts causes the trash objects to be destroyed when clicked and add to the total points.
*****************************************************************************/
using UnityEngine;

public class Trash : MonoBehaviour, IClick
{
    /// <summary>
    /// Call the pointCollector Script
    /// </summary>
    private PointCollector pointCollector;
    [SerializeField] private GameObject explosionPrefab;
    /// <summary>
    /// Find the pointCollector script in the scene
    /// </summary>
    private void Start()
    {
        pointCollector = FindObjectOfType<PointCollector>();
    }

    /// <summary>
    /// OnClick, add points and destroy the object
    /// </summary>
    public void onClickAction()
    {
        pointCollector.PointsTotal += 100;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
