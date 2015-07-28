using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float health = 0.0f;
    public Transform projectileAnchor;

	// Use this for initialization
	void Start() 
	{
	
	}
	
	// Update is called once per frame
	void Update() 
    {
	    if (Input.GetKeyDown(KeyCode.Space))
            Fire();
	}

	public bool IsAlive()
	{
		return (health > 0.0f);
	}
    
    public void Fire()
    {
        Projectile projectileGo = Game.Create("Projectile").GetComponent<Projectile>();
        projectileGo.transform.SetParent(projectileAnchor, false);
        projectileGo.transform.localPosition = Vector3.zero;
    }
    
    public void OnCollisionEnter(Collision other)
    {
        // If we hit an enemy, destroy it...
        if (other != null)
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
                Die();
        }    
    }
    
    public void Die()
    {
        if (this != null && gameObject != null)
            GameObject.Destroy(gameObject);
    }
}
