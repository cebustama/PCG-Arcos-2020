using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Alumno
{
    PROFE,
    JORGE,
    ALEXANDER,
    MAXY,
    TOMAS,
    ENILEV,
    JUAN,
    BRANCO,
    RODRIGO,
    FRANCO
}

[CreateAssetMenu()]
public class GameData : ScriptableObject
{
    [System.Serializable]
    public struct ColorOption
    {
        public Color color;
        public Alumno alumno;
    }

    public ColorOption[] floorColors;
    public ColorOption[] wallColors;
    public ColorOption[] lightColors;

    public Material tileMaterial;
}
