using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 
{

    private int value;
    private int suit;
    private Sprite sprite;

    public Card(int value, int suit, Sprite sprite)
    {
        this.value = value;
        this.suit = suit;
        this.sprite = sprite;
    }


    public int getValue()
    {
        return value;
    }

    public int getSuit()
    {
        return suit;
    }

    public void removeSprite()
    {
        sprite = null;
    }

    public Sprite getSprite()
    {
        return sprite;
    }

    public bool equals(Card one, Card two)
    {
        if ((one.getSuit() == two.getSuit()) && (one.getValue() == two.getValue()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public override string ToString()
    {
        string returnThis = "";

        switch (value)
        {
            case 2:
                returnThis = "2 ";
                break;
            case 3:
                returnThis = "3 ";
                break;
            case 4:
                returnThis = "4 ";
                break;
            case 5:
                returnThis = "5 ";
                break;
            case 6:
                returnThis = "6 ";
                break;
            case 7:
                returnThis = "7 ";
                break;
            case 8:
                returnThis = "8 ";
                break;
            case 9:
                returnThis = "9 ";
                break;
            case 10:
                returnThis = "10 ";
                break;
            case 11:
                returnThis = "11 ";
                break;
            case 12:
                returnThis = "12 ";
                break;
            case 13:
                returnThis = "13 ";
                break;
            case 14:
                returnThis = "14 ";
                break;
        }

        switch (suit)
        {
            case 1:
                returnThis = returnThis + "of Spades";
                break;
            case 2:
                returnThis = returnThis + "of Clubs";
                break;
            case 3:
                returnThis = returnThis + "of Diamonds";
                break;
            case 4:
                returnThis = returnThis + "of Hearts";
                break;
        }

        return returnThis;
    }



}
