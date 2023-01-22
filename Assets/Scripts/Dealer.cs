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

    [SerializeField]
    private ConcentrationGameProgressionManager concentrationGameProgressionManager;

    [SerializeField]
    private ConcentrationPlayerBase Player;

    [SerializeField]
    private ConcentrationPlayerBase CPU;

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
                // �Q�[���̃X�e�[�g��Choice�ȊO��������A��
                if (concentrationGameProgressionManager.GetGameStates !=
                ConcentrationGameProgressionManager.GameStates.Choice)
                {
                    return;
                }

                switch (ActorTurn) 
                {
                    
                    
                    // Player�̃^�[����������
                    case Turn.Player:
                        Player.CardChoice(card, cardImage);
                        if (!Player.IsMyTurn)
                        {
                            // �I�����ꂽ�J�[�h�𗠌�����
                            cardImage.sprite = CardAtlas.GetSprite($"Card_54");
                            Player.currentChoiceCardImage.sprite = CardAtlas.GetSprite($"Card_54");
                            ActorTurn = Turn.CPU;
                            return;
                        }
                        break;
                    // CPU�̃^�[����������
                    case Turn.CPU:
                        CPU.CardChoice(card, cardImage);
                        if (!CPU.IsMyTurn)
                        {
                            // �I�����ꂽ�J�[�h�𗠌�����
                            cardImage.sprite = CardAtlas.GetSprite($"Card_54");
                            CPU.currentChoiceCardImage.sprite = CardAtlas.GetSprite($"Card_54");
                            ActorTurn = Turn.Player;
                            return;
                        }
                        break;
                }
                
                cardImage.sprite = CardAtlas.GetSprite($"Card_{((int)card.CardSuit * 13) + card.Number - 1}");
            });
        }

        Debug.Log($"�X�[�g�F{Deck.CardDeck.FirstOrDefault().CardSuit} " + 
            $"�����F{Deck.CardDeck.FirstOrDefault().Number}");
    }

}
