using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip trapSound;
    [SerializeField] private AudioClip throwSound;
    [SerializeField] private AudioClip winSound;

    public void PlayHealSound()
    {
        SoundFXManager.instance.PlaySoundFXClip(healSound, transform, .5f);

    }

    public void PlayTrapDamageSound()
    {
        SoundFXManager.instance.PlaySoundFXClip(trapSound, transform, .5f);

    }

    public void PlayThrowSound()
    {
        SoundFXManager.instance.PlaySoundFXClip(throwSound, transform, .5f);

    }
    
    public void PlayWinSound()
    {
        SoundFXManager.instance.PlaySoundFXClip(winSound, transform, .5f);

    }
}
