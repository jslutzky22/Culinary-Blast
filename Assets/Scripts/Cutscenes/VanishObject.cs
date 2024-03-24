/*****************************************************************************
// File Name : VanishObject.cs
// Author : Jake Slutzky
// Creation Date : March 19, 2024
//
// Brief Description : This script will hide a game object once a "start vanishing" is triggered and after a duration.
*****************************************************************************/
using UnityEngine;

public class VanishObject : MonoBehaviour
{
    [SerializeField] float duration;
    private float timer = 0.0f;
    private bool isVanishing = false;
    [SerializeField] GameObject _willVanish;

   /// <summary>
   /// This will hide a gameObject after a duration is met
   /// </summary>
    void Update()
    {
        if (isVanishing)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                _willVanish.SetActive(false);
                isVanishing = false;
            }
        }
    }

    /// <summary>
    /// The method to start the fanishing process
    /// </summary>
    public void StartVanishing()
    {
        isVanishing = true;
        timer = 0.0f;
    }

    /// <summary>
    /// Vanish object instantly
    /// </summary>
    public void VanishNow()
    {
        _willVanish.SetActive(false);
    }
}
