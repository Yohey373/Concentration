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

    public RectTransform GetCardBGRoot
    {
        get { return cardBG; }
    }

    [SerializeField]
    private ConcentrationGameProgressionManager concentrationGameProgressionManager;

    [SerializeField]
    private ConcentrationPlayerBase Player;

    [SerializeField]
    private ConcentrationPlayerBase CPU;

    public ConcentrationPlayerBase GetCPUConcentrationPlayer
    {
        get { return CPU; }
    }

    public int GetPlayerCardCount
    {
        get { return Player.Score; }
    }

    public int GetCPUCardCount
    {
        get { return CPU.Score; }
    }

    // Start is called before the first frame update
    public void Deal()
    {
        Deck.GetDeck();

        Player.PlayerInitialize(CardAtlas.GetSprite($"Card_54"), TurnChange);
        CPU.PlayerInitialize(CardAtlas.GetSprite($"Card_54"), TurnChange);

        // Linqにおける例：Where
        // ラムダ式でboolを判定し。List内に判定条件に合致する要素を返す。
        var clubCards = Deck.CardDeck.Where(card => card.CardSuit == Card.Suit.Club).ToList();
        var clubOne = clubCards.FirstOrDefault();
        // clubの1
        // Linqにおける例：any
        // ラムダ式でboolを判定し、List内に判定条件に合致するかtrueかfalseで返す。
        var clubCardsInHeartCard = clubCards.Any(card => card.CardSuit == Card.Suit.Heart);
        // false

        StartCoroutine(FinishDealingCards());
    }

    private IEnumerator FinishDealingCards()
    {

        foreach (var card in Deck.CardDeck)
        {
            var cardImage = Instantiate(CardImage, cardBG);
            // InstantiateされたcardImageからCardButtonExtensionを取得する
            var cardButton = cardImage.gameObject.GetComponent<CardButtonExtension>();
            // cardButton の引数で使う表示する用の画像をSpriteAtlasから取得する。
            var cardSprite = CardAtlas.GetSprite($"Card_{((int)card.CardSuit * 13) + card.Number - 1}");
            // cardButtonの引数で使う隠す用の画像をSpriteAtlasから取得する。
            var hideCardSprite = CardAtlas.GetSprite($"Card_54");
            cardButton.Initialize(cardSprite, hideCardSprite, () =>
            {
                switch (ActorTurn)
                {
                    case Turn.Player:
                        Player.CardChoice(card, cardImage);
                        break;
                    case Turn.CPU:
                        CPU.CardChoice(card, cardImage);
                        break;
                }
            });

        }
        // 産み終わってから1フレーム待つ
        yield return new WaitForEndOfFrame();
        // GridLayoutGroupを外す
        cardBG.GetComponent<GridLayoutGroup>().enabled = false;
    }

    /// <summary>
    /// ターン変更のメソッド
    /// </summary>
    private void TurnChange()
    {
        switch (ActorTurn)
        {
            case Turn.Player:
                if (!Player.IsMyTurn)
                {
                    ActorTurn = Turn.CPU;
                    CPU.IsMyTurn = true;
                }
                break;
            case Turn.CPU:
                if (!CPU.IsMyTurn)
                {
                    ActorTurn = Turn.Player;
                    Player.IsMyTurn = true;
                }
                break;
        }
    }

}
