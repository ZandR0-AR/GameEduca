using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject homePanel;
    public GameObject gameOverPanel;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 0f;
        homePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    // ▶ INICIAR JUEGO
    public void StartGame()
    {
        homePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // 💀 GAME OVER
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    // 🔁 VOLVER A JUGAR (REINICIA NIVEL)
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 🏠 VOLVER AL HOME PANEL
    public void BackToHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ❌ SALIR DEL JUEGO
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
