/*****************************************************************************
// File Name : CursorController.cs
// Author : Jake Slutzky
// Creation Date : March 19, 2024
//
// Brief Description : This script allows the cursor to interact with objects via destroying and moving them via click.
                        It also changes the visuals and size of the cursor.
*****************************************************************************/
using UnityEngine;
using TMPro;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D cursor;
    [SerializeField] private Texture2D cursorClicked;
    [SerializeField] private CursorControls controls;
    private Camera mainCamera;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private int pointsTotal = 0;



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
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
        _pointsText.text = "Points: " + pointsTotal.ToString();
    }

    /// <summary>
    /// When the mouse is clicked, change the cursor to the clicked visual
    /// </summary>
    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
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
                        Debug.Log("Trash shot");
                        pointsTotal += 100;
                        _pointsText.text = "Points: " + pointsTotal.ToString();
                    }
                }
                //Debug.Log("3D Hit: " + hit.collider.tag);*/
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
        //Debug.Log(hotspot);
        Cursor.SetCursor(cursorType, hotspot, CursorMode.ForceSoftware);
       //Debug.Log(cursorType.ToString());
    }
}
