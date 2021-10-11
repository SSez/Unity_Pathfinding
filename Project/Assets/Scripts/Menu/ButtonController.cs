using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ButtonType
{
    START_GAME,
    RESTART,
    QUIT_GAME,
    MAIN_MENU,
    RESUME_GAME
}

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
    [SerializeField] private ButtonType buttonType;

    CanvasManager canvasManager;
    Button menuButton;

    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.GetInstance();
    }

    void OnButtonClicked()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (buttonType)
        {
            case ButtonType.START_GAME:
                //Call other code that is necessary to start the game like levelManager.StartGame()
                //canvasManager.SwitchCanvas(CanvasType.Game);
                SceneManager.LoadScene("PathfindingScene");
                Time.timeScale = 1f;
                UIManager.GameIsPaused = false;
                break;
            case ButtonType.RESTART:
                SceneManager.LoadScene(scene.name);
                Time.timeScale = 1f;
                UIManager.GameIsPaused = false;
                break;
            case ButtonType.RESUME_GAME:
                canvasManager.SwitchCanvas(CanvasType.EmptyCanvas);
                Time.timeScale = 1f;
                UIManager.GameIsPaused = false;
                break;
            case ButtonType.MAIN_MENU:
                SceneManager.LoadScene("MainMenu");
                break;
            case ButtonType.QUIT_GAME:
                Application.Quit();
                break;
            default:
                break;
        }
    }
}