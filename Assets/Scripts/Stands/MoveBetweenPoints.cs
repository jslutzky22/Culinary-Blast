/*****************************************************************************
// File Name : MoveBetweenPoints.cs
// Author : Jake Slutzky
// Creation Date : March 19, 2024
//
// Brief Description : This script causes the attached object to move between the array of points at a certain speed
*****************************************************************************/
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    /// <summary>
    /// The variables
    /// </summary>
    [SerializeField] private GameObject[] _movePoints;
    [SerializeField] private float _speed;
    private int currentIndex;

    /// <summary>
    /// On start, set the currentIndex or point being moved to as the 0th point
    /// </summary>
    void Start()
    {
        currentIndex = 0;
    }

    /// <summary>
    /// Every frame, move the object closer to the currentIndexed point. If it is close enough, start moving to the
    /// next point. If it reaches the last point in the list, go to the first one again.
    /// </summary>
    void Update()
    {
        if (Vector3.Distance(transform.position, _movePoints[currentIndex].transform.position) < 0.1f)
        {
            currentIndex++;

            if (currentIndex >= _movePoints.Length)
            {
                currentIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _movePoints[currentIndex].transform.position,
            _speed * Time.deltaTime);
    }
}
