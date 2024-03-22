using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    [SerializeField] private GameObject[] _movePoints;
    [SerializeField] private float _speed;
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Check the distance between platform and point
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
