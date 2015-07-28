using UnityEngine;
using System.Collections;

public class TestLevel : MonoBehaviour 
{
    public Transform enemySpawnPoint;

    // enemy spawn variables
    float lastSpawnTime = 0.0f;
    float spawnDelay = 1.5f;
    
    // Enemy spawn increase variables
    int enemiesPerSpawn = 1;
    float lastSpawnDelayDecreaseTime = 0.0f;
    float increaseSpawnRateInterval = 1.5f;
    
    void Awake()
    {
    }
    
    void Start ()
    {
        Game.SpawnPlayer();
    }
    
    void Update() 
    {
        if (Game.player != null)
        {
            float currTime = Time.realtimeSinceStartup;
            
            if ((currTime - lastSpawnTime) >= spawnDelay)
                SpawnEnemy();
                
            if ((currTime - lastSpawnDelayDecreaseTime) >= increaseSpawnRateInterval)
                DecreaseSpawnDelay();
                
            // If the last time we spawned enemies was longer than our spawn increase delay,
            // increase the number of enemies that spawn on each spawn
            /*
            if ((currTime - lastEnemyPerSpawnIncreaseTime) >= enemyPerSpawnIncreaseDelay)
                IncreaseSpawnCount();
            */
        }
    
        /*
        if (Game.player.IsAlive())
        {
            float currTime = Time.realtimeSinceStartup;
            
            // If the last time we spawned enemies was longer than our spawn increase delay,
            // increase the number of enemies that spawn on each spawn
            if ((currTime - lastEnemyPerSpawnIncreaseTime) >= enemyPerSpawnIncreaseDelay)
                IncreaseSpawnCount();
            
            // if the difference between now and the last time we spawned is 1.5 seconds or more,
            // spawn an artillery
            if ((currTime - lastSpawnTime) >= spawnDelay)
                SpawnEnemy();
                
            // whenever we want some behavior to be checked per frame or be checked every interval of time
            // we're going to need to another function, some variables in the class,
            // and another if check in our update loop...
            
            // every time two minutes passes by...
            // make individual enemies stronger
            
            // every time three minutes passes by...
            // make the enemies spawn more frequently
            
            // every time one minute passes by...
            // spawn a rare enemy for the player
            
            // ultimately...
            
            // every time x minutes passes by...
            // do some behavior
        }
        else // player is not alive
        {
            Game.Restart();
        }
        */
    }
    
    public void SpawnEnemy()
    {
        for (int i = 0; i < enemiesPerSpawn; ++i)
        {
            GameObject enemyGo = Game.Create("Enemy");
            enemyGo.transform.position = enemySpawnPoint.position;
            lastSpawnTime = Time.realtimeSinceStartup; // reset the timer
        }
    }
    
    public void DecreaseSpawnDelay()
    {
        // Reduce by 1 tenth, cap to .2f delay
        spawnDelay = Mathf.Max(spawnDelay - 0.15f, 0.2f);
        lastSpawnDelayDecreaseTime = Time.realtimeSinceStartup;
    }
    
    public void OnFireClicked()
    {
        // Try to make the player shoot if available
        if (Game.player != null)
            Game.player.Fire();
    }
}
