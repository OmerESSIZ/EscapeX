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
        Debug.Log("Oyun kapandý!"); // Unity Editörde test etmek için
        Application.Quit();
    }

}
