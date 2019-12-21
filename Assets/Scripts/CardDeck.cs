using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CardDeck : MonoBehaviour
{


    public Sprite[] cardDeckSprite = new Sprite[52];
    /*
     * Low to High
     * Spades
     * Clubs
     * Diamonds
     * Hearts
     */

    private List<Card> deck;
    private List<Card> deckInOrder;



    private void Start()
    {
    }


    public void InitCardDeck()
    {

        deck = new List<Card>();
        deckInOrder = new List<Card>();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                deck.Add(new Card(j + 2, i + 1, cardDeckSprite[(i * 13) + j]));
                deckInOrder.Add(new Card(j + 2, i + 1, cardDeckSprite[(i * 13) + j]));
            }
        }

    }

    public void shuffle()
    {
        List<Card> temp = new List<Card>();
        System.Random ran = new System.Random();
        int num;
        while (deck.Count > 0)
        {
            num = ran.Next(0, deck.Count);
            temp.Add(deck[num]);
            deck.RemoveAt(num);
        }

        deck = temp;

    }


    public List<Card> deal(int num)
    {
        List<Card> hand = new List<Card>();


        switch (num)
        {
            case 0:
                for (int i = 0; i < 13; i++)
                {
                    hand.Add((Card)deck[i]);
                }
                break;
            case 1:
                for (int i = 13; i < 26; i++)
                {
                    hand.Add((Card)deck[i]);
                }
                break;
            case 2:
                for (int i = 26; i < 39; i++)
                {
                    hand.Add((Card)deck[i]);
                }
                break;
            case 3:
                for (int i = 39; i < 52; i++)
                {
                    hand.Add((Card)deck[i]);
                }
                break;
        }



        hand = sortHand(hand, num);


        return hand;
    }


    public List<Card> sortHand(List<Card> hand, int num)
    {

        List<Card> spades = new List<Card>();
        List<Card> clubs = new List<Card>();
        List<Card> diamonds = new List<Card>();
        List<Card> hearts = new List<Card>();

        for (int i = 0; i < 13; i++)
        {
            int suit = hand[i].getSuit();
            switch (suit)
            {
                case 1:
                    spades.Add(hand[i]);
                    break;
                case 2:
                    clubs.Add(hand[i]);
                    break;
                case 3:
                    diamonds.Add(hand[i]);
                    break;
                case 4:
                    hearts.Add(hand[i]);
                    break;
            }
        }


        hand.Clear();



        spades = sortByNum(spades);


        diamonds = sortByNum(diamonds);
        clubs = sortByNum(clubs);
        hearts = sortByNum(hearts);

        hand.AddRange(spades);
        hand.AddRange(diamonds);
        hand.AddRange(clubs);
        hand.AddRange(hearts);
        return hand;
    }




    public List<Card> sortByNum(List<Card> cardsInSuit)
    {
        Card temp;
        for (int i = 0; i < cardsInSuit.Count; i++)
        {
            for (int j = 0; j < cardsInSuit.Count; j++) {

                if (cardsInSuit[i].getValue() < cardsInSuit[j].getValue())
                {
                    temp = cardsInSuit[j];
                    cardsInSuit[j] = cardsInSuit[i];
                    cardsInSuit[i] = temp;
                }
            }
        }
        return cardsInSuit;
    }


    public List<Card> removeFromHand(Card remove, List<Card> hand)
    {
        hand.Remove(remove);
        return hand;
    }







}
