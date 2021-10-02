using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private bool gameIsEnded = false;
    private float restartDelay = 0.5f;
    public void GameOver()
    {
        if (!gameIsEnded)
        {
            gameIsEnded = true;
            Debug.Log("game over");
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
