using UnityEngine;

public class Goal: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScreenManager.Instance.Open(ScreenType.WinLevel);
            Time.timeScale = 0;
        }
    }
}