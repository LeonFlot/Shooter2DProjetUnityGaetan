using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputMapController _playerInput;
    private InputAction _move;

    private Vector2 _MoveVector;
    [SerializeField]private int _moveSpeed;

    private Rigidbody _rigidbody;

    [SerializeField] private bool _useDebug;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = new InputMapController();
        _move = _playerInput.Player.Move;
    }

    private void OnEnable()
    {
        _move.Enable();
    }

    private void OnDisable()
    {
        _move.Disable();
    }

        

    // Update is called once per frame
    void Update()
    {
        // Verify if player input is null if is null dont use them
        if (_playerInput != null)
        {
            if (_useDebug) { Debug.Log(_playerInput.Player.Move.ReadValue<Vector2>().ToString()); }
            _MoveVector = _playerInput.Player.Move.ReadValue<Vector2>();
        }
        else
        {
            if (_useDebug) { Debug.LogWarning("Player input is null"); }
        }

    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_MoveVector.x * _moveSpeed, _MoveVector.y * _moveSpeed);
    }
}
