using Game;
using JSAM;
using System.Threading.Tasks;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    private void OnEnable()
    {
        AudioManager.OnAudioManagerInitialized += PlayMusicAfterInit;
    }

    private void OnDisable()
    {
        AudioManager.OnAudioManagerInitialized -= PlayMusicAfterInit;
    }
    private async void Start()
    {
        await Task.Delay(4000);
        PlayMusicAfterInit();
    }
    private void PlayMusicAfterInit()
    {
        var element = AudioManager.PlayMusic(LesonAudioMusic.MusicSFX, true);
    }
    public void PlayCoinSound()
    {
        AudioManager.PlaySound(LesonAudioSounds.HitSFX);
    }
    public void SetMusicVolume(float volume)
    {
        AudioManager.MusicVolume = volume; 
    }
    public void SetSoundVolume(float volume)
    {
        AudioManager.SoundVolume = volume;
    }
}
