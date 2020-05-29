using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioData : ScriptableObject
{
    [System.Serializable]
    public struct AudioOption
    {
        public AudioClip clip;
        public Alumno alumno;
    }

    public AudioOption[] songs;    
}
