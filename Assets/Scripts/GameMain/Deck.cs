using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    public List<Card> GetDeck()
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
        return CardDeck;
    }

    
}
