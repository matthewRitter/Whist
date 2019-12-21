using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private static int playerTeamScore = 0;

    private static int aITeamScore = 0;

    private static Card[][] lastTwoTricks = null;

    private static int dealer;

    private bool playingHand;


    public GameObject pHand;

    public GameObject e1Hand;

    public GameObject e2Hand;

    public GameObject e3Hand;


    private CardDeck deck;

    private int highestBid;


    private List<Card> playerHand;
    private List<Card> enemy1Hand;
    private List<Card> partnerHand;
    private List<Card> enemy3Hand;


    playerManager playerController;


    AIPlayer ai1;
    AIPlayer ai2;
    AIPlayer ai3;


    private void Start()
    {
        ai1 = new AIPlayer(3, enemy1Hand, 1);
        ai2 = new AIPlayer(0, partnerHand, 2);
        ai3 = new AIPlayer(1, enemy3Hand, 3);
        playerController = new playerManager();
    }



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

    public void startHand()
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

    public void dealHands()
    {
        deck = GameObject.FindWithTag("Player").GetComponent<CardDeck>();
        deck.InitCardDeck();
        deck.shuffle();
        playerHand = deck.deal(0);
        enemy1Hand = deck.deal(1);
        partnerHand = deck.deal(2);
        enemy3Hand = deck.deal(3);
    }


    public void bidHand()
    {
        int playerBid;
        int ai1Bid;
        int ai2Bid;
        int ai3Bid;

        //REWRITE THIS SWITCH
        switch (dealer) {
            case 0:
                playerBid = playerController.playerBid();
                if (playerBid != 0)
                {
                    highestBid = playerBid;
                }
            case 1:
                ai1Bid = ai1.makeBid();
                if (ai1Bid != 0)
                {
                    highestBid = ai1Bid;
                }
            case 2:
                ai2Bid = ai2.makeBid();
                if (ai2Bid != 0)
                {
                    highestBid = ai2Bid;
                }
            case 3:
                ai3Bid = ai3.makeBid();
                if (ai3Bid != 0)
                {
                    highestBid = ai3Bid;
                }
                break;
        }
    }

    public int getCurrentHighestBid()
    {
        return highestBid;
    }





    public void playHand()
    {

    }


}
