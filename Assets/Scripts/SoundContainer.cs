using UnityEngine;

public class SoundContainer : MonoBehaviour
{
    private static SoundContainer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
}
