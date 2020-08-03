using UnityEditor;
using UnityEngine;

public class MudTile : PathTile {


#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/MudTile")]
    public static void CreateMudTile() {
        string path = EditorUtility.SaveFilePanelInProject("Save Mud Tile", "New Mud Tile", "asset", "Save Mud Tile", "Assets");
        if (path == "") {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<MudTile>(), path);
    }

#endif
}