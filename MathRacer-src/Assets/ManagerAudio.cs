using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider musicVolumeSlider;

    private void Start()
    {
        // Inicializa el slider de volumen
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);

        // Configura el volumen inicial de la música
        musicSource.volume = musicVolumeSlider.value;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
