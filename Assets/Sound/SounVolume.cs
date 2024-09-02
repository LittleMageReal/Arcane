using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SounVolume : MonoBehaviour
{
   public AudioMixer masterVolume;
   public Slider slider;

   void Start()
   {
     float currentVolume;
     masterVolume.GetFloat("MasterSoun", out currentVolume); 
     slider.value = currentVolume;
   }

    public void SetVolume(float volume)
   {
     masterVolume.SetFloat("MasterSoun", volume);
   }
}
