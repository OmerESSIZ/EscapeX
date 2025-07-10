using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{
    public void TekrarOyna()
    {
        // Þu anki Level'ý baþtan yükler veya ilk leveli yükler
        SceneManager.LoadScene("Level1"); // Ýstersen önceki levelin ismini yaz
    }

    public void Level3Ac()
    {
        // Þu anki Level'ý baþtan yükler veya ilk leveli yükler
        SceneManager.LoadScene("Level3"); // Ýstersen önceki levelin ismini yaz
    }

    public void CikisYap()
    {
        // Oyundan çýkar
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
