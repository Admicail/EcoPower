using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public static CameraController instance;
    public CinemachineBrain CineCamera;
    private void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
