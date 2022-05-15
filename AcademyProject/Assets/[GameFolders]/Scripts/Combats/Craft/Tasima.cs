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
        //Canvasý buluyoruz
        Canvas = GameObject.Find("Canvases Craft");
        
    }
     public void OnMouseDrag()
    {
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,100));
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 15;//canvasýn önünde kalmasý için
        this.transform.position = mousePos;
        this.transform.SetParent(Canvas.transform);
        //this.transform.parent=Canvas.transform;

    }
}
