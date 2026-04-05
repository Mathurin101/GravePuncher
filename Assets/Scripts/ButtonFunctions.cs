using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{

    //TODO:controls/keybinds/rebinding

    //TODO:stats tab --need the saveStates

    public void Resume()
    {
        GameManager.Instance.UnpauseGame();
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayLocal()
    {
        //TODO: bring to the -- local play game scenes 
        //Time.timeScale = 1.0f;
        //SceneManager.LoadScene();
    }

    public void PlayOnline()
    {
        //TODO: bring to the -- online play game scenes or sever space with list and everything
        //Time.timeScale = 1.0f;
        //SceneManager.LoadScene();
    }

    public void Previous()
    {
        GameManager.Instance.PreviousButton();
    }

    public void Player1Info()
    {
        GameManager.Instance.InfoMenuP1Button();
    }



    public void Player2Info()
    {
        GameManager.Instance.InfoMenuP2Button();

    }

    public void Close()
    {
        GameManager.Instance.CloseButton();
    }

    public void Exit()
    {
        SceneManager.LoadScene("Name of main menu");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }



}
