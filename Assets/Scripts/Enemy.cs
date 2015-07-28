using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
    public float speed = 11.0f;

	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), 
            transform.position.y, 
            transform.position.z);
            
        if (transform.position.x <= -10.0f)
            Die();
	}
    
    public void Die()
    {
        if (this != null && gameObject != null)
            GameObject.Destroy(gameObject);
    }
    
    public void OnCollisionEnter(Collision other)
    {    
        // If we hit an enemy, destroy it...
        if (other != null)
        {
            var projectile = other.gameObject.GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.Die();
                Die();
            }
        }
    }
}
