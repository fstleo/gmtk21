using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteModeFinalScoreLabel : MonoBehaviour
{
    
    [SerializeField]
    private TextMeshProUGUI _scoreLabel;
    
    [SerializeField]
    private TextMeshProUGUI _maxScoreLabel;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "InfiniteMode")
        {
            _scoreLabel.text = "Walked: " + InfiniteModeScore.Scores + " meter" + (InfiniteModeScore.Scores == 1 ? "" : "s");
            _maxScoreLabel.text = "Maximum score: " + InfiniteModeScore.MaximumScores + " meter" + (InfiniteModeScore.MaximumScores == 1 ? "" : "s");
        }
        else
        {
            _scoreLabel.text = "";
            _maxScoreLabel.text = "";
        }
    }
}