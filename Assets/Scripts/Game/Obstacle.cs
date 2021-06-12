using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScreenManager.Instance.Open(ScreenType.GameOver);
            Time.timeScale = 0;
        }
    }
}