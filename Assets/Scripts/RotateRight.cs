using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRight : MonoBehaviour, IClick
{
    [SerializeField] GameObject player;
    public void onClickAction()
    {
        player.transform.Rotate(Vector3.up, 90f);
    }
}
