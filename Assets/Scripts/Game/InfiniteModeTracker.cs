using UnityEngine;

public class InfiniteModeTracker : MonoBehaviour
{
    private float _score = 0;
    
    private void Awake()
    {
        InfiniteModeScore.Scores = 0;
    }

    private void FixedUpdate()
    {
        _score += Time.fixedDeltaTime * 0.7f;
        InfiniteModeScore.Scores = Mathf.RoundToInt(_score);
    }
    
}