using UnityEngine;

public class UIManager : MonoBehaviour
{
    CanvasManager canvasManager;
    public static bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasManager = CanvasManager.GetInstance();
        canvasManager.SwitchCanvas(CanvasType.EmptyCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                resume();
                
            } else
            {
                pause();
            }
        }
    }

    void resume()
    {
        canvasManager.SwitchCanvas(CanvasType.EmptyCanvas);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void pause()
    {
        canvasManager.SwitchCanvas(CanvasType.PauseMenu);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
