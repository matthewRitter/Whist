using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    private static int playerTeamScore = 0;

    private static int aITeamScore = 0;

    private static Card[][] lastTwoTricks = null;

    private static int dealer;

    private bool playingHand;


    public int getPlayerScore()
    {
        return playerTeamScore;
    }

    public int getAIScore()
    {
        return aITeamScore;
    }

    public void addToAI(int bid)
    {
        aITeamScore += bid;
    }

    public void addToPlayer(int bid)
    {
        playerTeamScore += bid;
    }

    public void viewLastTwoTricks()
    {

    }

    public void setLastTrick(Card playerThrow, Card enemy1Throw, Card teammateThrow, Card enemy2Throw)
    {
        if (lastTwoTricks[0][0] != null)
        {
            for (int i = 0; i < 4; i++)
            {
                lastTwoTricks[1][i] = lastTwoTricks[0][i];
            }
        }
        lastTwoTricks[0][1] = playerThrow;
        lastTwoTricks[0][2] = enemy1Throw;
        lastTwoTricks[0][3] = teammateThrow;
        lastTwoTricks[0][4] = enemy2Throw;
    }


    public void pickDealer()
    {
        dealer = (int)Mathf.Floor(Random.Range(0, 4));
    }

    public void nextDealer()
    {
        dealer++;
    }

    public int getDealer()
    {
        return dealer;
    }

    public void playHand()
    {
        playingHand = true;
    }

    public void finishHand()
    {
        playingHand = false;
    }

    public bool getPlayingHand()
    {
        return playingHand;
    }


}
