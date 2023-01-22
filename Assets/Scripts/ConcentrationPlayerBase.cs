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
        // 1枚目に選択した場合の処理
        if (currentChoiceCard == null)
        {
            currentChoiceCard = choiceCard;
            currentChoiceCardImage = choiceCardImage;
            IsMyTurn = true;
            return;
        }

        // 同じカードを選んでいる場合は帰る
        if (choiceCard == currentChoiceCard)
        {
            return;
        }

        if (currentChoiceCard.Number == choiceCard.Number)
        {
            // ペアがそろったので消す
            currentChoiceCardImage.gameObject.SetActive(false);
            choiceCardImage.gameObject.SetActive(false);
            currentChoiceCard = null;
            // 自分のターンを続行
            IsMyTurn = true;
            // スコアを加算
            Score += 2;
        }
        else
        {
            // 自分のターンは終了
            currentChoiceCard = null;
            IsMyTurn = false;
        }

    }
}
