using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    [Header("Audio Clips")]
    public AudioClip hoverClip;
    public AudioClip pickupClip;
    public AudioClip dropClip;
    public AudioClip combinationClip;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlayHover() => Play(hoverClip);
    public void PlayPickup() => Play(pickupClip);
    public void PlayDrop() => Play(dropClip);
    public void PlayCombination() => Play(combinationClip);

    private void Play(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
