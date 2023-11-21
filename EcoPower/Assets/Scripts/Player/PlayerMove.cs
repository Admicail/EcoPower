using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _player;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _player = GetComponent<CharacterController>();
    }

    public void Move()
    {
        _moveDirection = ((transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"))) * _speed;
        _player.Move(_moveDirection * Time.deltaTime);
    }
}
