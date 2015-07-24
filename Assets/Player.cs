using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float health = 0.0f;

	// Use this for initialization
	void Start() 
	{
	
	}
	
	// Update is called once per frame
	void Update() 
    {
	
	}

	public bool IsAlive()
	{
		return (health > 0.0f);
	}
}
