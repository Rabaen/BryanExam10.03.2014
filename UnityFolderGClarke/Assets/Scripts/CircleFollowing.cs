using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CircleFollowing : MonoBehaviour 
{
	Vector3 velocity = Vector3.zero;
	Vector3 force = Vector3.zero;
	float mass = 1.0f;
	float maxSpeed = 5.0f;

	int currentWaypoint = 0;

	public List<GameObject> waypoints = new List<GameObject>();

	/*private void CreatePath(int points, float radius)
	{
		float theta = 0;
		for(i = 0; i < points; i++)
		{
			waypoints[i] = new Vector3(Mathf.Sin (theta), 0, Mathf.Cos(theta));
			waypoints.Add(i);
			theta +=36;
		}
	}*/

	//private void DrawPath()
	//{
	//	foreach(Vector3 waypoints[i] in waypoints[])
	//	{
	//		Debug.Drawline(waypoints[i], waypoints[i] + 1);
	//	}
	//}

	Vector3 Seek(Vector3 waypoint)
	{
		Vector3 desired = waypoint - transform.position;
		desired.Normalize();
		desired *= maxSpeed;
		return desired-velocity;
	}

	Vector3 followPath()
	{
		float distance = Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position);

		if(distance < 0.5f)
		{
			currentWaypoint += 1;
		}
	
		if(currentWaypoint >= waypoints.Count)
		{
			currentWaypoint = 0;
		}

	return Seek(waypoints[currentWaypoint].transform.position);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		force += followPath();

		Vector3 accel = force / mass;
		velocity = velocity + accel * Time.deltaTime;
		transform.position = transform.position + velocity * Time.deltaTime;
		velocity = Vector3.zero;
	}


}
