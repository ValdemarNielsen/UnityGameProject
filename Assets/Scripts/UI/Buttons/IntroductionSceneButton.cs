using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private Button IntroductionButton;
    // Start is called before the first frame update
    void Start()
    {
        IntroductionButton = GetComponent<Button>();
        IntroductionButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TaskOnClick()
    {
        SceneManager.LoadScene("GameStateScene");

    }


}
