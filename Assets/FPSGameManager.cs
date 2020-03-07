using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSGameManager : MonoBehaviour
{
    public List<PlayerController> players = new List<PlayerController>();

    public int pointsMultipler = 1;
    public float speedMultiplier = 1f;
    public float jumpForceMultiplier = 1f;

    public int round = 1;
    public static FPSGameManager instance;

    public struct Stats
    {
        public string playerName;
        public int killCount;
        public int deathCount;
        public int points;
    }

    public List<Stats> gameStats = new List<Stats>();

    private void Awake()
    {
        instance = this;
        #region Get Players
        GameObject[] playerObjs = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < playerObjs.Length; i++)
        {
            players.Add(playerObjs[i].GetComponent<PlayerController>());
        }
        #endregion
        // get all players
        // add players to stat board

    }

    public static void DoublePoints()
    {

    }

    public static void InstantKill()
    {

    }

    public static void MysteryBoxSale()
    {

    }

    public static void JumpBoost()
    {

    }

    public static void SpeedBoost()
    {

    }

    public static void GiveRandomPowerUp()
    {
        
    }

    public static void NextRound(FPSGameManager gameManager)
    {
        bool beginSpawning = false;
        gameManager.round++;
        instance.StartCoroutine(instance.Timer(10, beginSpawning));
        if (beginSpawning)
        {
            // do some round starting stuff here
        }
    }

    private IEnumerator Timer(float time, bool powerActive)
    {
        yield return new WaitForSeconds(time);
        powerActive = !powerActive;
    }
}
