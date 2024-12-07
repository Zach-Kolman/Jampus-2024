using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInWebGL : MonoBehaviour
{
    public void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
            gameObject.SetActive(false);
    }
}
