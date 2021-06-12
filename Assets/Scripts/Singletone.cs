using UnityEngine;

public class Singletone<T> : MonoBehaviour where T: Singletone<T>
{
    private static T _instance;
    public static T Instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
        
    } 
}