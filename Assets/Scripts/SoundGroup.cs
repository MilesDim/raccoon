using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnGroupSoundVolumeChange(float vol);
public class SoundGroup : MonoBehaviour {
    [Range(0,1)]
    public float Volume=1;
    float _volume;
    public OnGroupSoundVolumeChange VolumeChange;

    static List<SoundGroup> lst;

    public static SoundGroup GetGroup(string Name)
    {
        if (lst == null) lst = new List<SoundGroup>();

        foreach (SoundGroup s in lst) if (s.name == Name) return s;

        GameObject go = new GameObject();
        go.name = Name;
        DontDestroyOnLoad(go);
        SoundGroup sg= go.AddComponent<SoundGroup>();
        lst.Add(sg);
        return sg;
    }

    void Update()
    {
        if (Volume != _volume)
        {
            _volume = Volume;
            if (VolumeChange != null) VolumeChange(Volume);
        }

    }

}