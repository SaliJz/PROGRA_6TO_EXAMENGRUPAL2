using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleDialogGraph", menuName = "Story/Simple Dialog Graph")]
public class GenericRuntimeGraph : ScriptableObject
{
    [SerializeReference] public List<GenericRuntimeNode> nodes = new List<GenericRuntimeNode>();

    public ChoiceRuntimeNode[] GetChoicesAfter(int textNodeIndex)
    {
        return nodes
            .OfType<ChoiceRuntimeNode>()
            .Where(c => c.parentNodeIndex == textNodeIndex)
            .ToArray();
    }
}