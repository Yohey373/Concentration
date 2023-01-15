using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Dealer : MonoBehaviour
{
    
    private Deck Deck = new Deck();
    
    // Start is called before the first frame update
    void Start()
    {
        Deck.GetDeck();
        Debug.Log($"スート：{Deck.CardDeck.FirstOrDefault().CardSuit} " + 
            $"数字：{Deck.CardDeck.FirstOrDefault().Number}");
    }

}
