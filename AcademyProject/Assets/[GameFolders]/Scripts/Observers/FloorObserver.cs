using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AcademyProject.Observers
{
    public class FloorObserver : MonoBehaviour
    {
        [SerializeField] private GameObject floorObject;
        [SerializeField] private Material transparentMat;
        [SerializeField] private Material woodMat;
        
        private void Awake()
        {
            floorObject.gameObject.GetComponent<Renderer>().sharedMaterials[1] = woodMat;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // Material newMat = Resources.Load("wooden_floortiles", typeof(Material)) as Material;
                // floorObject.GetComponent<Renderer>().sharedMaterials[1] = newMat;

                floorObject.gameObject.GetComponent<Renderer>().sharedMaterials[1] = transparentMat;
                Debug.Log(floorObject.gameObject.GetComponent<Renderer>().materials[1]);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {    
                // Material newMat = Resources.Load("m_TransperentWall", typeof(Material)) as Material;
                // floorObject.GetComponent<Renderer>().sharedMaterials[1] = newMat;
                
                floorObject.gameObject.GetComponent<Renderer>().sharedMaterials[1] = woodMat;
            }
        }
    }
}