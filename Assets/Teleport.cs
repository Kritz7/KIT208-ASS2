using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			RaycastHit hit;
			
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10f))
			{
				if(hit.transform == this.transform)
				{
					GameObject player = GameObject.Find("First Person Controller");
					
					Vector3 posDiff = player.transform.position - transform.position;
					
					player.transform.position = GameObject.Find("!teleport1").transform.position + posDiff;
				}				
			}
		}
	}
}
