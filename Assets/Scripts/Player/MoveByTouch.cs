using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    [SerializeField] private float _MovementSpeed;

    private float _Movement = 0;

    private bool _TouchDetected = false;
    private bool _Jump = false;

    private int _LeftOrRight = 0;

    private Vector3 _WorldTouchPos;

    private Rigidbody2D rb;
    private CharacterController2D _Controller;

    public bool canMove = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _Controller = GetComponent<CharacterController2D>();
    }

    void Update()
    {
        if (Input.touches.Length != 0)
            _TouchDetected = true;
        else
            _TouchDetected = false;

        if (_TouchDetected)
        {
            if (canMove)
            {
                GetInput();
            }
        }
        else
        {
            _WorldTouchPos = new Vector3(0,0,0);
            _Movement = 0;
        }

        if (Input.touches.Length == 2)
        {
            _Jump = true;
        }
    }

    private void GetInput()
    {
        _WorldTouchPos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
        _WorldTouchPos.z = 0;

        if (_WorldTouchPos.x < transform.position.x - .5f)
        {
            _LeftOrRight = 0;
        }
        else if (_WorldTouchPos.x > transform.position.x + .5f)
        {
            _LeftOrRight = 1;
        }
        else
        {
            _Movement = 0;
        }
    }

    private void FixedUpdate()
    {
        if (_TouchDetected)
        {
            if (canMove)
            {
                MovePlayer(_LeftOrRight);
            }
        }

        _Controller.Move(_Movement, false, _Jump);
        _Jump = false;
    }

    // Right == 1, left == 0
    private void MovePlayer(int direction)
    {
        if(direction == 0)
        {
            _Movement = -_MovementSpeed * Time.deltaTime;
        }
        else if(direction == 1)
        {
            _Movement = _MovementSpeed * Time.deltaTime;
        }
    }
}
