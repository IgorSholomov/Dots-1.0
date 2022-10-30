using UnityEngine;

[CreateAssetMenu]
public class Config : ScriptableObject
{
    public int LevelWidth = 3;
    public int LevelHeight = 3;
    public int ChainLenght = 3;
    public int TestCount = 100000;
    public int AddRemoveCount = 5;
    public GameObject Graphy;
}