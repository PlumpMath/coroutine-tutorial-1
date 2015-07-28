using UnityEngine;
using System.Collections;

public class TestLevelCoroutine : MonoBehaviour 
{
    public Transform enemySpawnPoint;
    IEnumerator spawnEnemyCoroutine;
    IEnumerator accelerateSpawnRateCoroutine;

    // Enemy spawn variables
    float spawnRate = 1.5f;
    
    // Enemy spawn increase variables
    float accelerateSpawnInterval = 1.5f;

	// Use this for initialization
	void Start()
    {
        Game.SpawnPlayer();
    
        spawnEnemyCoroutine = WaitForSpawnEnemy();
        accelerateSpawnRateCoroutine = WaitForAccelerateSpawnRate();
        this.StartCoroutine(spawnEnemyCoroutine);
        this.StartCoroutine(accelerateSpawnRateCoroutine);
	}
	
	// Update is called once per frame
	void Update()
    {
        // Stops these coroutines, but what do these IEnumerators mean??
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.StopCoroutine(spawnEnemyCoroutine);
            this.StopCoroutine(accelerateSpawnRateCoroutine);
        }
	}
    
    public IEnumerator WaitForSpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            if (Game.player != null)
                SpawnEnemy();
        }
    }
    
    public IEnumerator WaitForAccelerateSpawnRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(accelerateSpawnInterval);
            AccelerateSpawnRate();
        }
    }
    
    public void SpawnEnemy()
    {
        GameObject enemyGo = Game.Create("Enemy");
        enemyGo.transform.position = enemySpawnPoint.position;
    }
    
    public void AccelerateSpawnRate()
    {
        // Reduce by 1 tenth, cap to .2f delay
        spawnRate = Mathf.Max(spawnRate - 0.15f, 0.2f);
    }
    
    public void OnFireClicked()
    {
        // Try to make the player shoot if available
        if (Game.player != null)
            Game.player.Fire();
    }
}
