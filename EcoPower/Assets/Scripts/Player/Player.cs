using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerMove), typeof(PlayerRotate))]
public class Player : MonoBehaviour
{
    private PlayerMove _move;
    private PlayerRotate _rotate;
    // Start is called before the first frame update
    private void Awake()
    {
        _move = GetComponent<PlayerMove>();
        _rotate = GetComponent<PlayerRotate>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
