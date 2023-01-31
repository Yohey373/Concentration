using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.U2D;
using UnityEngine.UI;
using TMPro;

public class Dealer : MonoBehaviour
{

    private Deck Deck = new Deck();

    [SerializeField]
    private SpriteAtlas CardAtlas;

    public Image CardImage;

    // �f�B�[���[�Ƀ^�[���𔻒肵�Ă��炤
    public enum Turn
    {
        Player,
        CPU
    }

    public Turn ActorTurn = Turn.Player;

    // 1�O�ɑI�������J�[�h
    private Card currentCard;
    // 1�O�ɑI�������J�[�h�C���[�W
    private Image currentCardImage;

    // �J�[�h�𐶂ރ��[�g
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

    public TextMeshProUGUI TurnOwnerText;

    // Start is called before the first frame update
    public void Deal()
    {
        Deck.GetDeck(true);

        Player.PlayerInitialize(CardAtlas.GetSprite($"Card_54"), TurnChange);
        CPU.PlayerInitialize(CardAtlas.GetSprite($"Card_54"), TurnChange);

        // Linq�ɂ������FWhere
        // �����_����bool�𔻒肵�BList���ɔ�������ɍ��v����v�f��Ԃ��B
        var clubCards = Deck.CardDeck.Where(card => card.CardSuit == Card.Suit.Club).ToList();
        var clubOne = clubCards.FirstOrDefault();
        // club��1
        // Linq�ɂ������Fany
        // �����_����bool�𔻒肵�AList���ɔ�������ɍ��v���邩true��false�ŕԂ��B
        var clubCardsInHeartCard = clubCards.Any(card => card.CardSuit == Card.Suit.Heart);
        // false

        StartCoroutine(FinishDealingCards());
    }

    private IEnumerator FinishDealingCards()
    {

        foreach (var card in Deck.CardDeck)
        {
            var cardImage = Instantiate(CardImage, cardBG);
            // Instantiate���ꂽcardImage����CardButtonExtension���擾����
            var cardButton = cardImage.gameObject.GetComponent<CardButtonExtension>();
            // cardButton �̈����Ŏg���\������p�̉摜��SpriteAtlas����擾����B
            var cardSprite = CardAtlas.GetSprite($"Card_{((int)card.CardSuit * 13) + card.Number - 1}");
            // cardButton�̈����Ŏg���B���p�̉摜��SpriteAtlas����擾����B
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
        // �Y�ݏI����Ă���1�t���[���҂�
        yield return new WaitForEndOfFrame();
        // GridLayoutGroup���O��
        cardBG.GetComponent<GridLayoutGroup>().enabled = false;
    }

    /// <summary>
    /// �^�[���ύX�̃��\�b�h
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
                    TurnOwnerText.text = "CPU Turn";
                }
                break;
            case Turn.CPU:
                if (!CPU.IsMyTurn)
                {
                    ActorTurn = Turn.Player;
                    Player.IsMyTurn = true;
                    TurnOwnerText.text = "Player Turn";
                }
                break;
        }
    }

}
