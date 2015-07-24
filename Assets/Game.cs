using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Game
{
    public static Player player;
    
    static GameObject currentLevel;
    static GameObject currentPopup;
    static Dictionary<string, UnityEngine.Object> cachedObjects = new Dictionary<string, UnityEngine.Object>();
    
    public static void SpawnPlayer()
    {
        // destroy player if we already have one
        if (player != null)
            GameObject.Destroy(player.gameObject);
            
        player = Game.Create("Player").GetComponent<Player>();
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
        if (!cachedObjects.ContainsKey(prefabName))
            cachedObjects[prefabName] = Resources.Load(prefabName);
            
        return (GameObject)Object.Instantiate(cachedObjects[prefabName]);
    }
    
    public static void Restart()
    {
    
    }
}
