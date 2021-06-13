using TMPro;
using UnityEngine;

public class InfiniteModeScoreLabel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoresLabel;
    
    private void Update()
    {
        _scoresLabel.text = InfiniteModeScore.Scores + " meter" + (InfiniteModeScore.Scores == 1 ? "" : "s");
    }
    
}