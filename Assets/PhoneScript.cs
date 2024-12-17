using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{

    public Transform socket;


    public void Attach()
    {
        transform.parent = socket.transform;
        transform.rotation = socket.rotation;
        transform.position = socket.position;
                
    }

}
