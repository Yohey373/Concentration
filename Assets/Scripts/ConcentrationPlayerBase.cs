using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConcentrationPlayerBase : MonoBehaviour
{

    public int Score;

    public Card currentChoiceCard;

    public Image currentChoiceCardImage;

    public virtual void CardChoice(Card choiceCard, Image choiceCardImage)
    {
        if (currentChoiceCard == null)
        {
            currentChoiceCard = choiceCard;
            currentChoiceCardImage = choiceCardImage;
            return;
        }

        if (currentChoiceCard.Number == choiceCard.Number)
        {
            // ÉyÉAÇ™ÇªÇÎÇ¡ÇΩÇÃÇ≈è¡Ç∑
            currentChoiceCardImage.gameObject.SetActive(false);
            choiceCardImage.gameObject.SetActive(false);
            currentChoiceCard = null;
            return;
        }

    }
}
