using UnityEngine;

public class TreeMemory : MonoBehaviour
{
    public static TreeMemory LastDeadlyTree { get; private set; }

    public void Remember()
    {
        LastDeadlyTree = this;
        Debug.Log("[TreeMemory] Запомнено дерево: " + gameObject.name);
    }

    public void DisableTree()
    {
        gameObject.SetActive(false);
    }

    public void HighlightTree()
    {
        
    }
}
