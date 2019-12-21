using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private List<Card> hand;
    private int numSeat;
    private int bid;


    public void playerController(List<Card> hand, int numSeat)
    {
        this.hand = hand;
        this.numSeat = numSeat;
        bid = -1;
    }
    

    public void playCard()
    {
        removeCard(hand[Random.Range(0, hand.Count)]);
    }

    public void playCard(Card card)
    {
        removeCard(card);
    }

    public void makeBid()
    {
        bid = 1;
    }
    public void makeBid(int bid)
    {
        this.bid = bid;
    }





    private void removeCard(Card card)
    {
        hand.Remove(card);
    }


    public void redeal(List<Card> hand)
    {
        this.hand = hand;
        bid = -1;
    }






}
