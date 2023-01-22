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

    // ディーラーにターンを判定してもらう
    public enum Turn
    {
        Player,
        CPU
    }

    public Turn ActorTurn = Turn.Player;

    // 1つ前に選択したカード
    private Card currentCard;
    // 1つ前に選択したカードイメージ
    private Image currentCardImage;

    // カードを生むルート
    [SerializeField]
    private RectTransform cardBG;

    [SerializeField]
    private ConcentrationPlayerBase Player;

    [SerializeField]
    private ConcentrationPlayerBase CPU;

    
    // Start is called before the first frame update
    private void Start()
    {
        Deck.GetDeck();
        
        // Linqにおける例：Where
        // ラムダ式でboolを判定し。List内に判定条件に合致する要素を返す。
        var clubCards = Deck.CardDeck.Where(card => card.CardSuit == Card.Suit.Club).ToList();
        var clubOne = clubCards.FirstOrDefault();
        // clubの1
        // Linqにおける例：any
        // ラムダ式でboolを判定し、List内に判定条件に合致するかtrueかfalseで返す。
        var clubCardsInHeartCard = clubCards.Any(card => card.CardSuit == Card.Suit.Heart);
        // false

        foreach (var card in Deck.CardDeck)
        {
            var cardImage = Instantiate(CardImage, cardBG);
            // カードを文字列をフックに表示する。
            //cardImage.sprite = CardAtlas.GetSprite($"Card_{((int)card.CardSuit * 13) + card.Number - 1}");
            cardImage.sprite = CardAtlas.GetSprite("Card_54");

            var button = cardImage.gameObject.AddComponent<Button>();

            button.onClick.AddListener(() =>
            {
                switch (ActorTurn) 
                { 
                    // Playerのターンだったら
                    case Turn.Player:
                        Player.CardChoice(card, cardImage);
                        break;
                    // CPUのターンだったら
                    case Turn.CPU:
                        CPU.CardChoice(card, cardImage);
                        break;
                }
                
                cardImage.sprite = CardAtlas.GetSprite($"Card_{((int)card.CardSuit * 13) + card.Number - 1}");
            });
        }

        Debug.Log($"スート：{Deck.CardDeck.FirstOrDefault().CardSuit} " + 
            $"数字：{Deck.CardDeck.FirstOrDefault().Number}");
    }

}
