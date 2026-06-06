using System;

[Serializable]
public class TextRuntimeNode : GenericRuntimeNode
{
    public string textES;
    public string textEN;
    public int nextNodeIndex = -1;
}