using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tasima : MonoBehaviour
{
    public int ItemId;
    public GameObject Canvas;
    private void Start()
    {
        //Canvas� buluyoruz
        Canvas = GameObject.Find("Canvases Craft");
        
    }
     public void OnMouseDrag()
    {
        // Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 mousePos = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,100));
        //mousePos.z = 15;//canvas�n �n�nde kalmas� i�in
        this.transform.position = mousePos;
        this.transform.SetParent(Canvas.transform);
        // this.transform.parent=Canvas.transform;

    }
}
