using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TypeDialogData : ScriptableObject
{
    public string Question;
    public string Answer1;
    public string Answer2;
    public TypeDialogData ReactToAnswer1;
    public TypeDialogData ReactToAnswer2;
}

