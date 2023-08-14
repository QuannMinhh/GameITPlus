using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character", menuName = "New Character")]

public class CharacterScriptableObj : ScriptableObject
{
    public int hp;
    public int defend;
    public int damage;
    public int luckyRate;
}
