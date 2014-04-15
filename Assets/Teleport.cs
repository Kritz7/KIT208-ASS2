using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	
	public bool PanelEnabled = true;
	
	Elevator attachedElevator;
	bool teleportActivated = false;
	
	// Use this for initialization
	void Start ()
	{
		attachedElevator = transform.root.GetComponent<Elevator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(teleportActivated)
		{
			if(attachedElevator.elevatorComplete)
			{
				MovePlayerToElevator();	
				teleportActivated = false;
			}
		}
		
		if(PanelEnabled && Input.GetKeyDown(KeyCode.Mouse0))
		{
			RaycastHit hit;
			
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10f))
			{
				if(hit.transform == this.transform)
				{
					teleportActivated = true;
					PanelEnabled = false;
					attachedElevator.TurnOn();
				}				
			}
		}
	}
	
	void MovePlayerToElevator()
	{
		GameObject player = GameObject.Find("First Person Controller");
		Teleport teleportPanel =  GameObject.Find("!teleport1").GetComponent<Teleport>();
		
		Vector3 posDiff = player.transform.position - transform.position;
		
		player.transform.position = teleportPanel.transform.position + posDiff;	
		
		teleportPanel.attachedElevator.TurnOn();
	}
}
