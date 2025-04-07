using UnityEngine;

public class PersistentMusicManager : MonoBehaviour
{
    public static PersistentMusicManager instance;

    [Header("Music Settings")]
    public AudioClip musicClip;
    [Range(0f, 1f)] public float musicVolume = 0.8f;

    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure only one instance exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SetupAudio();
    }

    private void SetupAudio()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.volume = musicVolume;
        audioSource.playOnAwake = false;

        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}
