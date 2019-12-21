using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIPlayer : MonoBehaviour
{
    private int numSeat;
    private int teammate;
    private List<Card> hand;

    private gameManager manager;



    public AIPlayer(int partner, List<Card> hand, int numSeat)
    {
        teammate = partner;
        this.hand = hand;
        this.numSeat = numSeat;
    }

    public int makeBid()
    {
        int bid = (int)Mathf.Floor(Random.Range(0, 3));
        if ((manager.getDealer()) % 4 == 0)
        {
            if (bid > manager.getCurrentHighestBid())
            {
                if (bid == 0)
                {
                    return 1;
                }
                else
                {
                    return bid;
                }
            }
            else
            {
                return 0;
            }
        }
        else
        {
            if (bid > manager.getCurrentHighestBid())
            {
                return bid;
            }
            else
            {
                return 0;
            }
        }
    }

    public Card playCard()
    {
        return hand[Random.Range(0, hand.Count)];
    }

    










    // Start is called before the first frame update
    void Start()
    {
        manager = new gameManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
