using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool paused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void OnPause(InputValue value){
        if (!paused){
            pauseScreen.SetActive(!pauseScreen.activeSelf);
            Time.timeScale = 0f;
            paused = true;
        } else {
            pauseScreen.SetActive(!pauseScreen.activeSelf);
            Time.timeScale = 1f;
            paused = false;
        }
	}
}
