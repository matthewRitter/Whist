using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public Sprite temp;


    public GameObject pHand;

    public GameObject e1Hand;

    public GameObject e2Hand;

    public GameObject e3Hand;


    private CardDeck deck;

    private List<Card> playerHand;
    private List<Card> enemy1Hand;
    private List<Card> partnerHand;
    private List<Card> enemy3Hand;

    // Start is called before the first frame update
    void Start()
    {
        deck = GameObject.FindWithTag("Player").GetComponent<CardDeck>();
        deck.InitCardDeck();
        deck.shuffle();
        playerHand = deck.deal(0);
        enemy1Hand = deck.deal(1);
        partnerHand = deck.deal(2);
        enemy3Hand = deck.deal(3);

        createGameObjectCards(playerHand, pHand);


        ScoreKeeper gameManager = new ScoreKeeper();
        gameManager.pickDealer();






    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void createGameObjectCards(List<Card> hand, GameObject parent)
    {
        for (int i = 0; i < 13; i++)
        {
            createCard(hand, "Card" + i, parent, i);
        }
    }

    public void createCard(List<Card> hand, string name, GameObject parent, int num)
    {
        GameObject card = new GameObject(name);
        card.transform.SetParent(parent.transform);
        card.AddComponent<SpriteRenderer>();//.sprite = hand[num].getSprite();
        card.GetComponent<SpriteRenderer>().sprite = hand[num].getSprite();
        card.transform.localScale *= 2;
        Vector3 position = parent.transform.position;
        position.x = position.x + num * 3 - 17;
        position.y += 2;
        card.transform.position = position;
    }














}
