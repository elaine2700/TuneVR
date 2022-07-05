using UnityEngine;

[CreateAssetMenu(fileName ="SongSettings", menuName ="Song Settings")]
public class SongSettings : ScriptableObject
{
    public AudioClip song;
    public int BMP;
    public string songName;
}
