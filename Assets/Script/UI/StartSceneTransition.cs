using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneTransition : MonoBehaviour
{
    public string characterSelectSceneName = "CharacterSelectScene";

    public void GoToCharacterSelect()
    {
        SceneManager.LoadScene(characterSelectSceneName);
    }
}
