using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform namlu,mermi,nokta;
    Transform klon;

    void Update()
    {
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;
        //
        // if (Input.GetMouseButton(0))
        // {
        //     if (Physics.Raycast(ray, out hit, 600))
        //     {
        //         var worldPosition = hit.point;
        //         worldPosition.y = 0;
        //         
        //         // transform.LookAt(worldPosition);
        //         Quaternion rotation = Quaternion.LookRotation(worldPosition, Vector3.up);
        //         transform.rotation = rotation;
        //     }
        //     
        //     _slingTime += Time.deltaTime;
        //     _currentSlingForce += _slingTime * 5.0f;
        //     
        //     if (_slingTime >= _maxSlingTime)
        //     {
        //         _slingTime = _maxSlingTime;
        //     }
        //
        //     if (_currentSlingForce >= _maxSlingForce)
        //     {
        //         _currentSlingForce = _maxSlingForce;
        //     }
        // }
        //
        // if (Input.GetMouseButtonUp(0))
        // {
        //     klon = Instantiate(mermi, nokta.position, namlu.rotation);
        //     klon.GetComponent<Rigidbody>().AddForce(klon.up * _currentSlingForce);
        //     _currentSlingForce = 0.0f;
        //     _slingTime = 0.0f;
        // }
    }
}