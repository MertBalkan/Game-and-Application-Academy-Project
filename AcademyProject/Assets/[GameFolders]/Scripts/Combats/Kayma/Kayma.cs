using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kayma : MonoBehaviour
{
    Rigidbody rig;
   
   
    public float slidespeed = 10f;
    bool isSliding;

    private void Start()
    {

        rig = GetComponent<Rigidbody>();

    }
    
    void Update()
    {
        

      
    }
     private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("cube"))
         {
             Sliding();
         }
         else
         {
             GoUp();
         }
     }
    private void Sliding()
    {
        rig.AddForce(transform.forward * slidespeed, ForceMode.VelocityChange);
    }

    private void GoUp()
    {
        
    }
}
