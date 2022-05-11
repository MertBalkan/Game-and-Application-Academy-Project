using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform top, namlu,mermi,nokta;
    Transform klon;

    public float _slingTime;
    private float _maxSlingTime = 2.0f;
    public float _currentSlingForce = 0;
    private float _maxSlingForce = 1000;
    
    void Update()
    {
        top.Rotate(0, Input.GetAxis("Horizontal"), 0);
        namlu.Rotate(0,0, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.Space))
        {
            _slingTime += Time.deltaTime;
            _currentSlingForce += _slingTime * 5.0f;
            
            if (_slingTime >= _maxSlingTime)
            {
                _slingTime = _maxSlingTime;
            }

            if (_currentSlingForce >= _maxSlingForce)
            {
                _currentSlingForce = _maxSlingForce;
            }
        }

        Debug.Log("CURRENT SLING TIME: " + _slingTime);
        Debug.Log("CURRENT SLING FORCE: " + _currentSlingForce);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            klon = Instantiate(mermi, nokta.position, namlu.rotation);
            klon.GetComponent<Rigidbody>().AddForce(klon.up * _currentSlingForce * -1);
            _currentSlingForce = 0.0f;
            _slingTime = 0.0f;
        }
    }
}