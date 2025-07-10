using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{
    public void TekrarOyna()
    {
        // �u anki Level'� ba�tan y�kler veya ilk leveli y�kler
        SceneManager.LoadScene("Level1"); // �stersen �nceki levelin ismini yaz
    }

    public void Level3Ac()
    {
        // �u anki Level'� ba�tan y�kler veya ilk leveli y�kler
        SceneManager.LoadScene("Level3"); // �stersen �nceki levelin ismini yaz
    }

    public void CikisYap()
    {
        // Oyundan ��kar
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
