/*****************************************************************************
// File Name : CursorController.cs
// Author : Jake Slutzky
// Creation Date : March 19, 2024
//
// Brief Description : This script allows the cursor to interact with objects via destroying and moving them via click.
                        It also changes the visuals and size of the cursor.
*****************************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CursorController : MonoBehaviour
{
    [SerializeField] private AudioClip laser;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Texture2D cursor;
    [SerializeField] private Texture2D cursorClicked;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CursorControls controls;
    [SerializeField] private float xTurnOff;
    private Camera mainCamera;
    private PointCollector pointCollector;
    private InputAction quit;
    private InputAction restart;
    [SerializeField] private AudioClip incorrectSound;
    [SerializeField] private AudioSource MyAudioSource;
    [SerializeField] private GameObject bigX;


    /// <summary>
    /// On awake, the CursorControls will be found. The cursor will be changed to the visual I gave it.
    /// The cursor will be locked to the screen. The mainCamera will be the Camera.main.
    /// </summary>
    private void Awake()
    {
        controls = new CursorControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }

    /// <summary>
    /// Notation for events. On start, get the StartedClick function. Normally you pass in a parameter but I just want
    /// the click, thus underscore.
    /// </summary>
    private void Start()
    {
        _playerInput.currentActionMap.Enable();
        quit = _playerInput.currentActionMap.FindAction("Quit");
        quit.started += quitStarted;
        restart = _playerInput.currentActionMap.FindAction("Restart");
        restart.started += restartStarted;
        pointCollector = FindObjectOfType<PointCollector>();
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
        //_pointsText.text = "Points: " + pointsTotal.ToString();
    }

    /// <summary>
    /// On restartStarted, reload the current scene
    /// </summary>
    /// <param name="context"></param>
    private void restartStarted(InputAction.CallbackContext context)
    {
        SceneManager.GetActiveScene();
    }

    /// <summary>
    /// on quitStarted, quit application
    /// </summary>
    /// <param name="context"></param>
    private void quitStarted(InputAction.CallbackContext context)
    {
        Debug.Log("quit");
        Application.Quit();
    }

    /// <summary>
    /// On destroy/reload of scene,delete the controls
    /// </summary>
    private void OnDestroy()
    {
        controls.Mouse.Click.started -= _ => StartedClick();
        controls.Mouse.Click.performed -= _ => EndedClick();
        restart.started -= restartStarted;
        quit.started -= quitStarted;
    }

    /// <summary>
    /// When the mouse is clicked, change the cursor to the clicked visual
    /// </summary>
    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
        audioSource.PlayOneShot(laser);
    }

    /// <summary>
    /// When the cursor is unclicked. Change the visual to the unclicked visual.
    /// </summary>
    private void EndedClick()
    {
        ChangeCursor(cursor);
        DetectObject();
    }

    /// <summary>
    /// Detects when an object is being pressed on using raycasts
    /// Can also make it go a certain distance and shoot through things as well
    /// Also ensures an object is being clicked prior to doing the onClickAction
    /// Also makes it so that if the object clicked was trash, add 100 points
    /// </summary>
    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)) 
        {
            if (hit.collider != null)
            {
                IClick click = hit.collider.gameObject.GetComponent<IClick>();
                if (click != null)
                {
                    click.onClickAction();
                    if (hit.collider.tag == "Trash")
                    {
                        
                        pointCollector.PointsTotal += 100;
                    }
                    if (hit.collider.tag == "Fruit")
                    {
                        StartCoroutine(misfire());
                    }
                }
            }
        }
    }

    /// <summary>
    /// Enables the controls
    /// </summary>
    private void OnEnable()
    {
        controls.Enable();
    }

    /// <summary>
    /// Disables the controls
    /// </summary>
    private void OnDisable()
    {
        controls.Disable();
    }

    /// <summary>
    /// Force software used to force it to be big instead of auto sizing. Also alters the visual of the cursor based
    /// on the current mode (clicked or unclicked) of the mouse.
    /// </summary>
    /// <param name="cursorType"></param>
    private void ChangeCursor(Texture2D cursorType)
    {
        Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, hotspot, CursorMode.ForceSoftware);
    }
    private IEnumerator misfire()
    {
        bigX.SetActive(true);
        MyAudioSource.PlayOneShot(incorrectSound, 1.0f);
        yield return new WaitForSeconds(xTurnOff);
        bigX.SetActive(false);
    }
}
