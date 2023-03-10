using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ConcentrationPlayerBase : MonoBehaviour
{

    public int Score;

    public Card currentChoiceCard;

    public Image currentChoiceCardImage;

    public bool IsMyTurn = false;

    // プレイヤーが裏返すため
    public Sprite hideCardSprite;

    // プレイヤーがカードを選択した際の処理
    public UnityAction CardChoiceCallback;

    public virtual void PlayerInitialize(Sprite hideCardSprite, UnityAction cardChoiceCallback)
    {
        Score = 0;
        this.hideCardSprite = hideCardSprite;
        this.CardChoiceCallback += cardChoiceCallback;
    }

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
            StartCoroutine(PairChoice(choiceCardImage));
        }
        else
        {
            // ミスした際の処理
            StartCoroutine(MissChoice(choiceCardImage));
        }

    }

    IEnumerator PairChoice(Image choiceCardImage)
    {
        yield return new WaitForSeconds(1f);
        // ペアがそろったので消す
        currentChoiceCardImage.gameObject.SetActive(false);
        choiceCardImage.gameObject.SetActive(false);
        currentChoiceCard = null;
        // 自分のターンを続行
        IsMyTurn = true;
        // スコアを加算
        Score += 2;
    }

    IEnumerator MissChoice(Image choiceCardImage)
    {
        yield return new WaitForSeconds(1f);
        // 自分が選んだカードを裏側に
        choiceCardImage.sprite = hideCardSprite;
        currentChoiceCardImage.sprite = hideCardSprite;
        // 自分のターンは終了
        currentChoiceCard = null;
        IsMyTurn = false;
        // カード選択が終わった際のコールバック
        CardChoiceCallback?.Invoke();
    }

}
