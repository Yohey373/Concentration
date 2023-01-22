using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardHelper
{
    /// <summary>
    /// �W���[�J�[�ȊO�̃J�[�h�̍ő喇��
    /// </summary>
    public const int CardMax = 52;

    /// <summary>
    /// �J�[�h�̐������߂�1~13
    /// </summary>
    /// <param name="_num"></param>
    /// <returns></returns>
    public static int CardNumJudge(int _num)
    {
        for (int i = 0; i < 13; i++)
        {
            if (_num % 13 == i)
            {
                return i + 1;
            }
        }
        return 0;
    }

    /// <summary>
    /// �J�[�h�̃X�[�g�����߂�0~3
    /// 0:Club
    /// 1:Dia
    /// 2:Heart
    /// 3:Spade
    /// </summary>
    /// <param name="_num"></param>
    /// <returns></returns>
    public static Card.Suit CardSuitJudgge(int _num)
    {
        for (int i = 0; i < (int)Card.Suit.Max; i++)
        {
            if (_num / 13 == i)
            {
                return(Card.Suit)i;
            }
        }
        return Card.Suit.Invalid;
    }

}
