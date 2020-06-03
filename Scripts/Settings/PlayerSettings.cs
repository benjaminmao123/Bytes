using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerSettings : MonoBehaviour
{
    public float sensitivity = 5;
    public string playerName = "Player";
    public float volume = 0.5f;
    public string characterRoot = "Remy";
    public string character = "RemyPlayer";

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sensitivitySlider;

    private void Start()
    {
        volumeSlider.value = volume;
        sensitivitySlider.value = sensitivity;

        if (PlayerPrefs.HasKey("sensitivity"))
            volume = PlayerPrefs.GetFloat("sensitivity");
        if (PlayerPrefs.HasKey("playerName"))
            playerName = PlayerPrefs.GetString("playerName");
        if (PlayerPrefs.HasKey("volume"))
            volume = PlayerPrefs.GetFloat("volume");

        PlayerPrefs.SetFloat("sensitivity", sensitivity);
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.SetString("characterRoot", characterRoot);
        PlayerPrefs.SetString("character", character);
        PlayerPrefs.Save();
    }

    public void OnLeaveSettings()
    {
        volume = volumeSlider.value;
        sensitivity = sensitivitySlider.value;

        PlayerPrefs.SetFloat("sensitivity", sensitivity);
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.SetString("characterRoot", characterRoot);
        PlayerPrefs.SetString("character", character);
        PlayerPrefs.Save();
    }
}
