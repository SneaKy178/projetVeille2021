using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private bool gameIsEnded = false;
    private float restartDelay = 2f;
    public void GameOver()
    {
        if (!gameIsEnded)
        {
            SoundManagerScript.PlaySound("gameOver");
            gameIsEnded = true;
            Invoke("Restart", restartDelay);

        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
