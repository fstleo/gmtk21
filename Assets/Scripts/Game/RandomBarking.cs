using UnityEngine;

public class RandomBarking : MonoBehaviour
{
    [SerializeField]
    private float _chance;
    
    private void Update()
    {
        if (Random.Range(0f, 1f) < _chance)
        {
            SoundsManager.Instance.PlaySound(SoundId.Bark);
        }
    }
}