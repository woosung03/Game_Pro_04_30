using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");  // 정확히 Game 씬의 이름과 일치시켜야 함
    }

    public void ExitGame()
    {
        Application.Quit(); // 실행 파일에서만 동작, 에디터에서는 안 꺼짐
    }
}
