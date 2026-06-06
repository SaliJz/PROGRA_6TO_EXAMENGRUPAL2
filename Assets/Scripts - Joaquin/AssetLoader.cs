using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;

public class AssetLoader : MonoBehaviour
{
    [SerializeField] private List<AssetReference> characterRefs;
    private readonly List<GameObject> loadedCharacters = new();

    public void LoadCharacters(List<Vector3> spawnPoints)
    {
        for (int i = 0; i < characterRefs.Count && i < spawnPoints.Count; i++)
        {
            int idx = i;
            Vector3 pos = spawnPoints[idx];
            characterRefs[idx].InstantiateAsync(pos, Quaternion.identity).Completed += handle => OnCharacterLoaded(handle, idx);
        }
    }

    private void OnCharacterLoaded(AsyncOperationHandle<GameObject> handle, int idx)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            loadedCharacters.Add(handle.Result);
        }
        else
        {
            Debug.LogError($"Failed to load character {idx}");
        }
    }

    private void OnDestroy()
    {
        foreach (var go in loadedCharacters)
        {
            Addressables.ReleaseInstance(go);
        }
    }
}