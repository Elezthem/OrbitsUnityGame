using UnityEngine;

public class SoundManager_orbits : MonoBehaviour
{
    public static SoundManager_orbits Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private AudioSource _effectSource;

    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }
}
