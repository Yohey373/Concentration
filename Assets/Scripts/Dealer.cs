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

    public Image CardImage;

    // �J�[�h�𐶂ރ��[�g
    [SerializeField]
    private RectTransform cardBG;
    
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
        var clubCardsInHeartCard = clubCards.Any(card => card.CardSuit == Card.Suit.Heart);
        // false

        foreach (var card in Deck.CardDeck)
        {
            var cardImage = Instantiate(CardImage, cardBG);
            // �J�[�h�𕶎�����t�b�N�ɕ\������B
            //cardImage.sprite = CardAtlas.GetSprite($"Card_{((int)card.CardSuit * 13) + card.Number - 1}");
            cardImage.sprite = CardAtlas.GetSprite("Card_54");

            var button = cardImage.gameObject.AddComponent<Button>();

            button.onClick.AddListener(() =>
            { 
               cardImage.sprite = CardAtlas.GetSprite($"Card_{((int)card.CardSuit * 13) + card.Number - 1}");
            });
        }

        Debug.Log($"�X�[�g�F{Deck.CardDeck.FirstOrDefault().CardSuit} " + 
            $"�����F{Deck.CardDeck.FirstOrDefault().Number}");
    }

}
