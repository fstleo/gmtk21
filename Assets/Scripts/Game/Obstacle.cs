using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScreenManager.Instance.Open(ScreenType.GameOver);
            Time.timeScale = 0;
        }
    }
}