using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameEnded = false;
    public GameObject completeGameUI;

	public void GameOver()
    {
        gameEnded = true;
        Debug.Log("Congratulations, you found the Red Cube!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}