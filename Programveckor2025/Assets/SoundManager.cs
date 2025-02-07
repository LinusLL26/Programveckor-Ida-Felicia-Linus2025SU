using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject SelectSound;

    public void PlaySelectSound()
    {
        GameObject SelectSoundClone = Instantiate(SelectSound);
        Destroy(SelectSoundClone, 0.5f);
    }
}
