using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressData 
{
    public int level;
    public bool backgroundSoundEnabled,swipeSoundEnabled;
    public ProgressData(int lvl,bool bgSE,bool sSE){
         level=lvl;
         backgroundSoundEnabled = bgSE;
         swipeSoundEnabled=sSE;
    }
    public void updatelevel(int lvl){
         level=lvl;
    }
    public void updateBGS(bool bgSE){
         backgroundSoundEnabled = bgSE;
    } 
    public void updateSS(bool sSE){
         swipeSoundEnabled=sSE;
    }
}
