using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Dealer : MonoBehaviour
{
    
    private Deck Deck = new Deck();

    [SerializeField]
    private SpriteAtlas CardAtlas;

    public Image card;
    
    // Start is called before the first frame update
    private void Start()
    {
        Deck.GetDeck();
        
        // Linq�ɂ������FWhere
        // �����_����bool�𔻒肵�BList���ɔ�������ɍ��v����v�f��Ԃ��B
        var clubCards = Deck.CardDeck.Where(card => card.CardSuit == Card.Suit.Club).ToList();
        var clubOne = clubCards.FirstOrDefault();
        // club��1
        // Linq�ɂ������Fany
        // �����_����bool�𔻒肵�AList���ɔ�������ɍ��v���邩true��false�ŕԂ��B
        var clubCardsInHeartCard = Deck.CardDeck.Any(card => card.CardSuit == Card.Suit.Heart);
        // false

        // �J�[�h�𕶎�����t�b�N�ɕ\������B
        card.sprite = CardAtlas.GetSprite($"Card_{((int)clubOne.CardSuit * 13) + clubOne.Number - 1}");

        Debug.Log($"�X�[�g�F{Deck.CardDeck.FirstOrDefault().CardSuit} " + 
            $"�����F{Deck.CardDeck.FirstOrDefault().Number}");
    }

}
