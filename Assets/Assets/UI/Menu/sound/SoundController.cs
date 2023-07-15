using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("music", Mathf.Log10(volume)*20);
    }
    public void SetSoundVolume()
    {
        float volume = soundSlider.value;
        mixer.SetFloat("sound", Mathf.Log10(volume)*20);
    }
}
