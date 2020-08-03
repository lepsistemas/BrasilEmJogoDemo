using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeTile : Tile {
    
    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go) {
        if (go != null) {
            go.GetComponent<SpriteRenderer>().sortingOrder = (position.y * 2) * -1;
            return base.StartUp(position, tilemap, go);
        }
        return false;
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/TreeTile")]
    public static void CreateTreeTile() {
        string path = EditorUtility.SaveFilePanelInProject("Save Tree Tile", "New Tree Tile", "asset", "Save Tree Tile", "Assets");
        if (path == "") {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<TreeTile>(), path);
    }

#endif

}