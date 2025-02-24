using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TypeMonologData : ScriptableObject
{
    public string Answer1;
    public string Answer2;
    public TypeMonologData ReactToAnswer1;
    public TypeMonologData ReactToAnswer2;
}

