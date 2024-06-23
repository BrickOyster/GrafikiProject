using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeCntrl : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider;
    public Slider effectSlider;
    public Slider musicSlider;
    
    // Start is called before the first frame update
    public void SetLevel(){
        mixer.SetFloat("MasterVol", 20*Mathf.Log10(masterSlider.value));
        mixer.SetFloat("EffectVol", 20*Mathf.Log10(effectSlider.value));
        mixer.SetFloat("MusicVol", 20*Mathf.Log10(musicSlider.value));
    }
}
