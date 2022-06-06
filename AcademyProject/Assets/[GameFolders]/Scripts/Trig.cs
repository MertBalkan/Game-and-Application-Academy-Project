using System;
using Cinemachine;
using UnityEngine;

public class Trig : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera currentCamera;
    [SerializeField] private CinemachineVirtualCamera[] otherCams;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var cam in otherCams)
                cam.gameObject.SetActive(false);
            currentCamera.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentCamera.gameObject.SetActive(false);
            otherCams[0].gameObject.SetActive(true);
        }
    }
}
