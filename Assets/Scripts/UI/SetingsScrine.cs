using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetingsScrine : MonoBehaviour
{
    [SerializeField] private PlaySound _playSound;
    [SerializeField] private TMP_Text _soundVolumsText;
    [SerializeField] private TMP_Text _musicVolumsText;

    [SerializeField] private Slider _musicVolumsSlider;
    [SerializeField] private Slider _soundVolumsSlider;

    [SerializeField] private TMP_Text _lobiScoreText;

    private int _lobiScore;
    private void Start()
    {
        _soundVolumsSlider.value = PlayerPrefs.GetFloat(Constants.SoundsVolumeKey, 1f);
        _musicVolumsSlider.value = PlayerPrefs.GetFloat(Constants.MusicVolumeKey, 1f);
        _soundVolumsText.text = ((int)(_soundVolumsSlider.value * 100)).ToString();
        _musicVolumsText.text = ((int)(_musicVolumsSlider.value * 100)).ToString();

        LoadTotalScore();
    }

    public void OnMusicSliderChanged(float value)
        {
        _playSound.SetMusicVolume(value);
        _musicVolumsText.text = ((int)(value * 100)).ToString();
        PlayerPrefs.SetFloat(Constants.MusicVolumeKey, (float)value);
        PlayerPrefs.Save();
    }
    public void OnSoundSliderChanged(float value)
    {
        _playSound.SetSoundVolume(value);
        _soundVolumsText.text = ((int)(value * 100)).ToString();
        PlayerPrefs.SetFloat(Constants.SoundsVolumeKey, (float)value);
        PlayerPrefs.Save();
    }
    private void LoadTotalScore()
    {
        PlayerData data = GameSaver.Load();
        int totalScore = data != null ? data.TotalScore : 0;
        _lobiScoreText.text = totalScore.ToString();
    }



}
