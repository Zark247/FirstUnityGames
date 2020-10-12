using UnityEngine;

public class EndGame : MonoBehaviour {

    public GameManager gm;

    private void OnTriggerEnter()
    {
        gm.GameOver();
    }
}
