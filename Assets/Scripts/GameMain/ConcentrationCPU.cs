using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConcentrationCPU : ConcentrationPlayerBase
{
    public TextMeshProUGUI ScoreText;
    public GameObject mainCamera;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="choiceCard"></param>
    /// <param name="choiceCardImage"></param>
    public override void CardChoice(Card choiceCard, Image choiceCardImage)
    {
        var gameMode = mainCamera.GetComponent<ConcentrationGameProgressionManager>().GetGameMode;
        
        base.CardChoice(choiceCard, choiceCardImage);
        
        if(gameMode == 0){
            ScoreText.text = $"Player2 Score:{Score}";
        }
        else {
            ScoreText.text = $"CPU Score:{Score}";
        }

    }
}
