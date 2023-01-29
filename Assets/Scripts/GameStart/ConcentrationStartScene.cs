using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ConcentrationStartScene : MonoBehaviour
{
    [SerializeField]
    private Button OnePlayerStartButton;
    [SerializeField]
    private Button TwoPlayerStartButton;

    void Start()
    {
        OnePlayerStartButton.onClick.AddListener(() =>
        {
            GameSceneUtil.Instance.SingleSceneTransration(
                ConcentrationGameStringResource.CNCENTRATION_GAME_MAIN_SCENE,
                () => OnePlayerStartButtonAction());
        });

        TwoPlayerStartButton.onClick.AddListener(() =>
        {
            GameSceneUtil.Instance.SingleSceneTransration(
                ConcentrationGameStringResource.CNCENTRATION_GAME_MAIN_SCENE);
        });

    }

    public void OnePlayerStartButtonAction()
    {
        // GameMain‚É‚¢‚éConcentrationGameProgresionManager‚ðŽæ“¾
        var gameProgressionManagerGameObject = 
            GameSceneUtil.Instance.NextSceneRootGetGameObjects.Where(x => x.GetComponent<ConcentrationGameProgressionManager>()).FirstOrDefault();

        if (gameProgressionManagerGameObject != null)
        {
            var gameProgressionManager =
                gameProgressionManagerGameObject.GetComponent<ConcentrationGameProgressionManager>();
            gameProgressionManager.GameMode = ConcentrationGameProgressionManager.GameModes.CPUCardIsComputersChoice;
        }
    }

}
