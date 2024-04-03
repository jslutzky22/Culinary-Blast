using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotClick : MonoBehaviour, IClick
{
    [SerializeField] private GameObject resetSpot;
    public void onClickAction()
    {
        //ADD BIG X
        transform.position = resetSpot.transform.position;
        //Destroy(gameObject);
    }
}
