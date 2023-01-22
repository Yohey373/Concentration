using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUtil : SingletonMonoBehaviour<GameSceneUtil>
{
    /// <summary>
    /// �V�[�����Ăяo��
    /// </summary>
    /// <param name="sceneName"></param>
    public void SingleSceneTransration(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}