using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D cursor;
    [SerializeField] private Texture2D cursorClicked;
    private CursorControls controls;

    // Start is called before the first frame update
    private void Awake()
    {
        controls = new CursorControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
    }

    /// <summary>
    /// Notation for events. On start, get the StartedClick function. Normally you pass in a parameter but I just want
    /// the click, thus underscore.
    /// </summary>
    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }

    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
    }

    private void EndedClick()
    {
        ChangeCursor(cursor);
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    /// <summary>
    /// Force software used to force it to be big instead of auto sizing.
    /// </summary>
    /// <param name="cursorType"></param>
    private void ChangeCursor(Texture2D cursorType)
    {
        Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, hotspot, CursorMode.ForceSoftware);
    }
}
