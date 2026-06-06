using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //public static SceneLoader Instance { get; private set; }

    //private void Awake() 
    //{ 
    //    Instance = this; 
    //    DontDestroyOnLoad(gameObject); 
    //}

    public void LoadScene(string name) => SceneManager.LoadScene(name);
    public void LoadMainMenu() => LoadScene("MainMenu");
    public void LoadLevel() => LoadScene($"Level");
    public void LoadVictory() => LoadScene("VictoryScreen");
    public void LoadDefeat() => LoadScene("DefeatScreen");
    public void QuitGame() { Application.Quit(); Debug.Log("Quit Game"); }
}