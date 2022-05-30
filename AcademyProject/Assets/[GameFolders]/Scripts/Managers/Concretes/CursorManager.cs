using System;
using AcademyProject.Managers;
using UnityEngine;

public class CursorManager : SingletonMonoBehaviour<CursorManager>
{
    [SerializeField] private Texture2D fireCursor;
    [SerializeField] private Texture2D normalCursor;
    private Vector2 _cursorPoint;

    private void Awake()
    {
        ApplySingleton(this);
    }

    private void Start()
    {
        _cursorPoint = new Vector2(fireCursor.width / 2, fireCursor.height / 2);
        SetNormalCursor();
    }

    public void SetFireCursor()
    {
        Cursor.SetCursor(fireCursor, _cursorPoint, CursorMode.Auto);
    }

    public void SetNormalCursor()
    {
        Cursor.SetCursor(normalCursor, _cursorPoint, CursorMode.Auto);
    }
}
