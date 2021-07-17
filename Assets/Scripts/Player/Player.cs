using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private MazeCell currentCell;
    private MazeDoor door;
    private Vector3 MoveDirection;
    private bool canMove = true;
    private float horizontalMovement;
    private float verticalMovement;
    private float speed = 3f;
    private readonly float movementMultiplyer = 10f;
    private float rbDrag = 6f;
    private MazeCellEdge edge;
    public LayerMask grounded;
    public LayerMask DoorMask;

    public Rigidbody rb;
    public ToggleCam camManager;

    public bool OpenDoor = false;

    private void Awake()
    {
        camManager.FPSview();
        GetComponent<Player>().enabled = true;
    }

    public void Setpos(MazeCell cell)
    {
        currentCell = cell;
        transform.localPosition = cell.transform.position;
        transform.position = new Vector3(transform.position.x, 4, transform.position.z);
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, -transform.up, .1f + 1f, grounded))
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }

        if (canMove)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");

            MoveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;

            ControllDrag();
        }

        if (Physics.Raycast(transform.position, transform.forward, .1f + 1f, DoorMask))
        {
            OpenDoor = true;
        }
        else
        {
            OpenDoor = false;
        }
    }

    private void ControllDrag()
    {
        rb.drag = rbDrag;
    }

    private void FixedUpdate()
    {
        rb.AddForce(MoveDirection.normalized * speed * movementMultiplyer, ForceMode.Acceleration);
    }
}
