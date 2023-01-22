using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConcentrationStartScene : MonoBehaviour
{
    [SerializeField]
    Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            GameSceneUtil.Instance.SingleSceneTransration(
                ConcentrationGameStringResource.CNCENTRATION_GAME_MAIN_SCENE);
        });
    }
}
