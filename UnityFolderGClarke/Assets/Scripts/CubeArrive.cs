using UnityEngine;
using System.Collections;

public class CubeArrive : MonoBehaviour 
{
	Vector3 velocity = Vector3.zero;
	Vector3 force = Vector3.zero;
	float maxSpeed = 7.0f;
	float mass = 1.0f;
	Vector3 target;
	public GameObject targetWaypoint;
	float slowingDistance = 5.0f;
	int waypointR = 0;

	Vector3 ArriveAtTarget(Vector3 target)
	{
		target = targetWaypoint.GetComponent<CircleFollowing>().waypoints[waypointR].transform.position;
		Vector3 targetOffset = target - transform.position;
		float distance = Vector3.Distance(target, transform.position);
		if (distance <= 0.5f)
		{
			waypointR = Random.Range(0,9);

		}
		float rampedSpeed = (distance / slowingDistance);
		float clippedSpeed = (rampedSpeed / maxSpeed);
		Vector3 desiredVelocity = (clippedSpeed / distance) * targetOffset;
		return desiredVelocity - velocity;
	}

	// Use this for initialization
	void Start () 
	{
		target = targetWaypoint.GetComponent<CircleFollowing>().waypoints[waypointR].transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{



		force += ArriveAtTarget (target);
		
		Vector3 accel = force / mass;
		velocity = velocity + accel * Time.deltaTime;
		transform.position = transform.position + velocity * Time.deltaTime;
		velocity = Vector3.zero;



	}
}
