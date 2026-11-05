using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    private GameControls controls;
    public bool IsPaused { get; private set; }

    private void Awake() => controls = new GameControls();

    //Dopo aver assegnato un valore a gameControls ne abilitiamo la mappa Player
    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Pause.performed += OnPausePerformed;
        resumeButton.onClick.AddListener(Resume);
    }
    private void OnDisable()
    {
        controls.Player.Enable();
        controls.Player.Pause.performed += OnPausePerformed;
        resumeButton.onClick.AddListener(Resume);
    }
    private void OnDestroy() => controls.Dispose();

    void SetPause(bool paused)
    {
        IsPaused = paused;
        pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;



    }

    public void Resume()
    {
        SetPause(false);
    }

   private void OnPausePerformed(InputAction.CallbackContext context) => SetPause(!IsPaused);
}