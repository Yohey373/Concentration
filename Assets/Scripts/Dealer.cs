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
        Debug.Log($"�X�[�g�F{Deck.CardDeck.FirstOrDefault().CardSuit} " + 
            $"�����F{Deck.CardDeck.FirstOrDefault().Number}");
    }

}
