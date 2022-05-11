using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform top, namlu,mermi,nokta;
    Transform klon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        top.Rotate(0, Input.GetAxis("Horizontal"), 0);
        namlu.Rotate(Input.GetAxis("Vertical"),0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            klon=Instantiate(mermi, nokta.position, namlu.rotation);
            klon.GetComponent<Rigidbody>().AddForce(klon.forward * 1000f);
        }
    }
}
