using Game;
using JSAM;
using System.Threading.Tasks;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private async void Start()
    {
        await Task.Delay(4000);
        var element = AudioManager.PlayMusic(LesonAudioMusic.MusicSFX, true);
    }
}
