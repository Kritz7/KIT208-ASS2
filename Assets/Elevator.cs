using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	
	float speed = 4f;
	public float distToMoveDown = 10f;
	Vector3 oldPosition;
	public Vector3 newPosition;
	
	bool elevatorOn;
	public bool elevatorComplete = false;
	
	float t = 0; // duration of lerp
	
	public void TurnOn(bool on=true)
	{
		elevatorOn = on;
		newPosition = transform.position - new Vector3(0, distToMoveDown, 0);
		oldPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(elevatorOn)
		{
			t += (1/speed) * Time.deltaTime;
			
			print (t);
			
			transform.position = Vector3.Lerp(oldPosition, newPosition, t);
			
			if(t >= 1.0f)
			{
				elevatorComplete = true;
				elevatorOn = false;
			}
		}
	}
}
