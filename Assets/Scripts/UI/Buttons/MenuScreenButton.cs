using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreenButton : MonoBehaviour
{
    private Button menuButton;

    void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public async void TaskOnClick()
    {       

        SceneManager.LoadScene("GameStateScreen");
    }
}
