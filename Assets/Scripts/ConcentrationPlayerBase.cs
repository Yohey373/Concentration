using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConcentrationPlayerBase : MonoBehaviour
{

    public int Score;

    public Card currentChoiceCard;

    public Image currentChoiceCardImage;

    public bool IsMyTurn = false;

    public virtual void CardChoice(Card choiceCard, Image choiceCardImage)
    {
        // 1���ڂɑI�������ꍇ�̏���
        if (currentChoiceCard == null)
        {
            currentChoiceCard = choiceCard;
            currentChoiceCardImage = choiceCardImage;
            IsMyTurn = true;
            return;
        }

        if (currentChoiceCard.Number == choiceCard.Number)
        {
            // �y�A����������̂ŏ���
            currentChoiceCardImage.gameObject.SetActive(false);
            choiceCardImage.gameObject.SetActive(false);
            currentChoiceCard = null;
            // �����̃^�[���𑱍s
            IsMyTurn = true;
        }
        else
        {
            // �����̃^�[���͏I��
            currentChoiceCard = null;
            IsMyTurn = false;
        }

    }
}
