using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectExample", menuName = "ScriptableObjectExample")]
public class ScriptableObjectExample : ScriptableObject
{
    public int ExampleInt;
    public NestedScriptableObjectExample ScriptableObjectExampleNested;
}
