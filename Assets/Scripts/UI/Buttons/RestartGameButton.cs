using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGameButton : MonoBehaviour
{
    private Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public async void TaskOnClick()
    {
        GameManager.pointScore = 0;
        GameManager.UpdatePlayerPosition(2, 2);

        SceneManager.LoadScene("GameStateScreen");
    }
}
