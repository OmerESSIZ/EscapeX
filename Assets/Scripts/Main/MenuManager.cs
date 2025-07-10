using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("girisSahnesi");
    }
    public void QuitGame()
    {
        Debug.Log("Oyun kapand�!"); // Unity Edit�rde test etmek i�in
        Application.Quit();
    }

}
