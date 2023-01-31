using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Deck
{
    /// <summary>
    /// トランプのカードデック
    /// </summary>
    public List<Card> CardDeck = new List<Card>();

    /// <summary>
    /// 昇順のデックをGetする。
    /// </summary>
    /// <returns></returns>
    public List<Card> GetDeck(bool isShuffle = false)
    {
        // 一度作られたデッキがある場合はCardDeckを返す
        if (CardDeck.FirstOrDefault() != null)
        {
            return CardDeck;
        }

        // デッキがない場合はここでデッキを生成する
        for (int i = 0; i < CardHelper.CardMax; i++)
        {
            CardDeck.Add(new Card(CardHelper.CardSuitJudgge(i), CardHelper.CardNumJudge(i)));
        }

        // シャッフルする場合はCardDeckをGuidを使って並び替える
        if (isShuffle)
        {
            return CardDeck = CardDeck.OrderBy(card => Guid.NewGuid()).ToList();
        }

        return CardDeck;
    }

    
}
