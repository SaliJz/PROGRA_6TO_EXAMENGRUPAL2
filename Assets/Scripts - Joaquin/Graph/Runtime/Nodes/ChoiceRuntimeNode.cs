using System;

[Serializable]
public class ChoiceRuntimeNode : GenericRuntimeNode
{
    public int parentNodeIndex;
    public string labelES;
    public string labelEN;
    public int nextNodeIndex;
}