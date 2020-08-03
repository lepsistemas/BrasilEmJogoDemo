using UnityEditor;
using UnityEngine;

public class RoadTile : PathTile {

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/RoadTile")]
    public static void CreateRoadTile() {
        string path = EditorUtility.SaveFilePanelInProject("Save Road Tile", "New Road Tile", "asset", "Save Road Tile", "Assets");
        if (path == "") {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<RoadTile>(), path);
    }

#endif
}