using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StoneTile : Tile {
    
    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go) {
        if (go != null) {
            return base.StartUp(position, tilemap, go);
        }
        return false;
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/StoneTile")]
    public static void CreateStoneTile() {
        string path = EditorUtility.SaveFilePanelInProject("Save Stone Tile", "New Stone Tile", "asset", "Save Stone Tile", "Assets");
        if (path == "") {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<StoneTile>(), path);
    }

#endif

}