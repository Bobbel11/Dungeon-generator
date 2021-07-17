using UnityEngine;

public class MazeDoor : MazePassage 
{

	public Transform hinge;

	private MazeDoor OtherSideOfDoor 
	{
		get 
		{
			return otherCell.GetEdge(direction.GetOpposite()) as MazeDoor;
		}
	}

	public override void Initialize (MazeCell primary, MazeCell other, MazeDirection direction) 
{
		base.Initialize(primary, other, direction);
		if (OtherSideOfDoor != null) 
		{
			hinge.localScale = new Vector3(-1f, 1f, 1f);
			Vector3 p = hinge.localPosition;
			p.x = -p.x;
			hinge.localPosition = p;
		}
		for (int i = 0; i < transform.childCount; i++) 
		{
			Transform child = transform.GetChild(i);
			if (child != hinge) 
			{
				child.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
			}
		}
	}

	private float rotSpeed = 3f;
	[SerializeField] private float angle;
	private Vector3 Direction;
	private bool open;
	public LayerMask player;
	private Player playerScript;

    private void Start()
    {
		angle = transform.eulerAngles.y;
    }


	// work in progress
	// make new door with key
    private void Update()
    {
			if (Mathf.Round(hinge.localEulerAngles.y) != angle)
			{
				hinge.Rotate(Direction * rotSpeed);
			}

			if (Input.GetKeyDown(KeyCode.E) && open == false && playerScript.OpenDoor == true)
			{
				angle = 90;
				Direction = Vector3.up;
				open = true;
			}
			else if (Input.GetKeyDown(KeyCode.E) && open == true && playerScript.OpenDoor == false)
			{
				angle = 0;
				Direction = -Vector3.up;
				open = false;
			}
    }
}