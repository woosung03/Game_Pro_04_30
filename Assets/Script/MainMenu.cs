using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");  // ��Ȯ�� Game ���� �̸��� ��ġ���Ѿ� ��
    }

    public void ExitGame()
    {
        Application.Quit(); // ���� ���Ͽ����� ����, �����Ϳ����� �� ����
    }
}
