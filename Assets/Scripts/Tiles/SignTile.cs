using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SignTile : Tile {
    
    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go) {
        if (go != null) {
            return base.StartUp(position, tilemap, go);
        }
        return false;
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/SignTile")]
    public static void CreateSignTile() {
        string path = EditorUtility.SaveFilePanelInProject("Save Sign Tile", "New Sign Tile", "asset", "Save Sign Tile", "Assets");
        if (path == "") {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<SignTile>(), path);
    }

#endif

}