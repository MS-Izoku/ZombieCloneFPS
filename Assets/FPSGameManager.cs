using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSGameManager : MonoBehaviour
{
    public static List<PlayerController> players = new List<PlayerController>();
    public static int pointsMultipler = 1;
    public static float speedMultiplier = 1f;
    public static float jumpForceMultiplier = 1f;

    public struct stats
    {
        public string playerName;
        public int killCount;
        public int deathCount;
        public int points;
    }

    public List<stats> gameStats = new List<stats>();

    private void Awake()
    {
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

    private IEnumerator Timer(float time, bool powerActive)
    {
        yield return new WaitForSeconds(time);
        powerActive = !powerActive;
    }
}
