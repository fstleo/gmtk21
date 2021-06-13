using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    private GameObject _go;

    public void Open()
    {
        _go = gameObject;
        OnOpen();
    }

    public void Close()
    {
        OnClosed();
        Destroy(_go);
    }

    protected abstract void OnOpen();
    protected abstract void OnClosed();

    public void Click()
    {
        SoundsManager.Instance.PlaySound(SoundId.Click);
    }
}