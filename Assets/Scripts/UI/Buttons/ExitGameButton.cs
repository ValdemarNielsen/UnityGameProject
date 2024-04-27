using UnityEngine;
using UnityEngine.UI;


public class ExitGameButton : MonoBehaviour

{
    private Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TaskOnClick()
    {
        Application.Quit();

    }

}
