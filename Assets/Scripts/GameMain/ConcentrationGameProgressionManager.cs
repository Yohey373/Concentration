using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConcentrationGameProgressionManager : MonoBehaviour
{
    [SerializeField]
    private Dealer Dealer;

    public enum GameStates
    {
        Invalide = -1,
        Start,
        Deal,
        Choice,
        GameEnd
    }

    public enum GameModes
    {
        CPUCardIsPlayerChoice,
        CPUCardIsComputersChoice
    }

    public GameModes GameMode = GameModes.CPUCardIsPlayerChoice;

    private float choiceTime = 1f;

    private bool isCPUChoice = false;

    private GameStates gameState = GameStates.Invalide;

    public GameStates GetGameStates
    {
        get { return gameState; }
    }
    private void Update()
    {
        switch (gameState)
        {
            case GameStates.Invalide:
                gameState = GameStates.Start;
                break;
            case GameStates.Start:
                // スタート時の演出などしたい場合はここで指定する
                gameState = GameStates.Deal;
                break;
            case GameStates.Deal:
                Dealer.Deal();
                gameState = GameStates.Choice;
                break;

            case GameStates.Choice:
                // CPUのカードをコンピューターが選ぶ場合は
                if (GameMode == GameModes.CPUCardIsComputersChoice)
                {
                    if (Dealer.GetCPUConcentrationPlayer.IsMyTurn)
                    {
                        choiceTime -= Time.deltaTime;
                        if (choiceTime < 0)
                        {
                            var randChoice =
                                Random.Range(0, Dealer.GetCardBGRoot.GetComponentsInChildren<Button>().Length+1);
                            var randCount = 0;
                            isCPUChoice = false;
                            foreach (var card in Dealer.GetCardBGRoot.GetComponentsInChildren<Button>())
                            {
                                randCount++;
                                if (card.image != Dealer.GetCPUConcentrationPlayer.currentChoiceCardImage)
                                {
                                    if (card.gameObject.activeSelf && !isCPUChoice && randCount == randChoice)
                                    {
                                        card.onClick.Invoke();
                                        isCPUChoice = true;
                                    }
                                }
                            }
                            choiceTime = 1f;
                        }
                    }
                }
                if (Dealer.GetPlayerCardCount + Dealer.GetCPUCardCount == 52)
                {
                    gameState = GameStates.GameEnd;
                }
                break;
            case GameStates.GameEnd:
                if (Dealer.GetPlayerCardCount > Dealer.GetCPUCardCount)
                {
                    Debug.Log("Playerの勝ち");
                }
                else
                {
                    Debug.Log("CPUの勝ち");
                }
                break;
        }
    }

}
