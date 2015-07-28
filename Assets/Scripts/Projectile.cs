using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    public const float cleanupDistance = 20.0f;
    float speed = 16.0f;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    transform.position += (transform.forward * speed * Time.deltaTime);
        
        if (transform.position.x > cleanupDistance)
            Die();
	}
    
    public void Die()
    {
        if (this != null)
            GameObject.Destroy(gameObject);
    }
    
    public void OnCollisionEnter(Collision other)
    {
    }
}
