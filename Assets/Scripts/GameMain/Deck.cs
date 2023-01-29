using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Deck
{
    /// <summary>
    /// �g�����v�̃J�[�h�f�b�N
    /// </summary>
    public List<Card> CardDeck = new List<Card>();

    /// <summary>
    /// �����̃f�b�N��Get����B
    /// </summary>
    /// <returns></returns>
    public List<Card> GetDeck(bool isShuffle = false)
    {
        // ��x���ꂽ�f�b�L������ꍇ��CardDeck��Ԃ�
        if (CardDeck.FirstOrDefault() != null)
        {
            return CardDeck;
        }

        // �f�b�L���Ȃ��ꍇ�͂����Ńf�b�L�𐶐�����
        for (int i = 0; i < CardHelper.CardMax; i++)
        {
            CardDeck.Add(new Card(CardHelper.CardSuitJudgge(i), CardHelper.CardNumJudge(i)));
        }

        // �V���b�t������ꍇ��CardDeck��Guid���g���ĕ��ёւ���
        if (isShuffle)
        {
            return CardDeck = CardDeck.OrderBy(card => Guid.NewGuid()).ToList();
        }

        return CardDeck;
    }

    
}
