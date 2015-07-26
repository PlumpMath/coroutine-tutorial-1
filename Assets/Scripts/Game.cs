using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Game
{
    public static Player player;
    
    public static GameObject currentLevel;
    static GameObject currentPopup;
    static Dictionary<string, UnityEngine.Object> cachedObjects = new Dictionary<string, UnityEngine.Object>();
    
    public static void SpawnPlayer()
    {
        // destroy player if we already have one
        if (player != null)
            GameObject.Destroy(player.gameObject);
            
        player = Game.Create("Player").GetComponent<Player>();
        
        GameObject playerSpawnPoint = GameObject.Find("PlayerSpawn");
        player.transform.position = playerSpawnPoint.transform.position;
    }

    public static void OpenLevel(string levelName)
    {
        // clean up current level if we already have one
        if (currentLevel != null)
            GameObject.Destroy(currentLevel);
            
        // create and start the new level...
        currentLevel = Game.Create(levelName);
    }
    
    public static void GameOver()
    {
        // show game over popup
        if (currentPopup != null)
            GameObject.Destroy(currentPopup);
            
        currentPopup = Game.Create("GameOverPopup");
        currentPopup.transform.position = Vector3.zero;
    }
    
    public static GameObject Create(string prefabName)
    {
        // Full path: Assets/Resources/MyPrefab/MyPrefab
        // prefabPath: MyPrefab/MyPrefab
        string prefabPath = prefabName + "/" + prefabName;
    
        if (!cachedObjects.ContainsKey(prefabPath))
            cachedObjects[prefabPath] = Resources.Load(prefabPath);
            
        return (GameObject)Object.Instantiate(cachedObjects[prefabPath]);
    }
    
    public static void Restart()
    {
    
    }
}
