using System;
using AcademyProject.Managers;
using UnityEngine;

public class CursorManager : SingletonMonoBehaviour<CursorManager>
{
    [SerializeField] private Texture2D fireCursor;
    [SerializeField] private Texture2D normalCursor;
    
    private Vector2 _fireCursorPoint;
    private Vector2 _normalCursorPoint;
    
    private void Awake()
    {
        ApplySingleton(this);
    }

    private void Start()
    {
        _normalCursorPoint = new Vector2(normalCursor.width / 2, normalCursor.height / 2);
        _fireCursorPoint = new Vector2(fireCursor.width / 2, fireCursor.height / 2);
        SetNormalCursor();
    }

    public void SetFireCursor()
    {
        Cursor.SetCursor(fireCursor, _fireCursorPoint, CursorMode.Auto);
    }

    public void SetNormalCursor()
    {
        Cursor.SetCursor(normalCursor, _normalCursorPoint, CursorMode.Auto);
    }
}
