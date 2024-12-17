using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Transform parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        parent.GetComponent<CameraSwitcher>().SwitchCamera();
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    parent.GetComponent<CameraSwitcher>().SwitchCameraMain();
    //}
}
