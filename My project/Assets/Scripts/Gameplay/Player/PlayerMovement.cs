using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _freezeTime = 0.1f;

    [SerializeField] private float playerSpeed = 5.0f;

    private PlayerController _controller;
    // Start is called before the first frame update

    private void OnEnable()
    {
        PlayerController.Damaged += StopMovementForSeconds;
    }

    private void OnDisable()
    {
        PlayerController.Damaged -= StopMovementForSeconds;
    }

    void Start()
    {
        _controller = PlayerController.Instance;
        playerSpeed = _moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    void Move()
    {
        Vector2 movementInput =_controller.Input.Touch.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, movementInput.y,0 );
        transform.position += move * (_moveSpeed * Time.deltaTime);
    }

    void StopMovementForSeconds()
    {
        StartCoroutine(StopMovementForSecondsCo());
    }

    IEnumerator StopMovementForSecondsCo()
    {
        _moveSpeed = 0;
        yield return new WaitForSeconds(_freezeTime);
        _moveSpeed = playerSpeed;
    }
}
