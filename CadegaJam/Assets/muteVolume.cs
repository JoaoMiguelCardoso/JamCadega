using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteVolume : MonoBehaviour
{
    public void mute(bool toggle){
        if(toggle){
            AudioListener.volume = 0f;
        }else{
            AudioListener.volume = 1f;
        }
    }
}
