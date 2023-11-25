using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkybooxRotation : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}
