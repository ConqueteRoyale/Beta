using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//2018-09-15
//Kevin Langlois
//Script qui controle les options du jeu
//Source Brackeys youtube
public class MenuOptions : MonoBehaviour {

    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int resolutionCourante = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) 
            {
                resolutionCourante = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = resolutionCourante;
        resolutionDropdown.RefreshShownValue();
    }

    public void ChangerResolution( int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ChangerVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void ChangerGraphiques( int indexGraphiques)
    {
        QualitySettings.SetQualityLevel(indexGraphiques);
    }

    public void PleinEcran (bool plein)
    {
        Screen.fullScreen = plein;
    }
        

}
