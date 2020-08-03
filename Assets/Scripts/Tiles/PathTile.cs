using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class PathTile : Tile {

    [SerializeField]
    private Sprite[] sprites = null;

    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go) {
        return base.StartUp(position, tilemap, go);
    }

    public override void RefreshTile(Vector3Int position, ITilemap tilemap) {
        for (int y = -1; y <= 1; y++) {
            for (int x = -1; x <= 1; x++) {
                Vector3Int nPos = new Vector3Int(position.x + x, position.y + y, position.z);
                if (this.IsPath(tilemap, nPos)) {
                    tilemap.RefreshTile(nPos);
                }
            }
        }
    }

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData) {
        string composition = string.Empty;

        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                if (x != 0 || y != 0) {
                    if (this.IsPath(tilemap, new Vector3Int(location.x + x, location.y + y, location.z))) {
                        composition += 'P'; 
                    }
                    else {
                        composition += 'E';
                    }
                }
            }
        }

        if (composition == "EEEPEPPE" || composition == "PEEPEPPE") {
            tileData.sprite = this.sprites[0];
        } else if(composition == "EEEEPEPP") {
            tileData.sprite = this.sprites[6];
        } else if(composition == "PPEPEEEE" || composition == "PPEPEPEE") {
            tileData.sprite = this.sprites[2];
        } else if(composition == "EPPEPEEE" || composition == "EPPEPEEP" || composition == "PPPEPEEE") {
            tileData.sprite = this.sprites[8];
        } else if(composition == "PPEPEPPE" || composition == "PPEPEPPP" || composition == "PPPPEPPE") {
            tileData.sprite = this.sprites[1];
        } else if(composition == "EPPEPEPP" || composition == "EPPEPPPP" || composition == "PPPEPEPP") {
            tileData.sprite = this.sprites[7];
        } else if(composition == "EEEPPPPP" || composition == "PEEPPPPP" || composition == "EEPPPPPP") {
            tileData.sprite = this.sprites[3];
        } else if(composition == "PPPPPEEE" || composition == "PPPPPPEE" || composition == "PPPPPEEP") {
            tileData.sprite = this.sprites[5];
        } else if (composition == "PPEPPPPP") {
            tileData.sprite = this.sprites[12];
        } else if (composition == "PPPPPPPE") {
            tileData.sprite = this.sprites[11];
        } else if (composition == "EPPPPPPP") {
            tileData.sprite = this.sprites[10];
        } else if (composition == "PPPPPEPP") {
            tileData.sprite = this.sprites[9];
        } else {
            tileData.sprite = this.sprites[4];
        }
    }

    private bool IsPath(ITilemap tilemap, Vector3Int position) {
        return tilemap.GetTile(position) == this;
    }
}
