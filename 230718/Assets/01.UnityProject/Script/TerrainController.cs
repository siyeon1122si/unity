using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    private const string TILE_FRONT_RENDERER_OBJ_NAME = "FrontRenderer";

    private TerrainType terrainType = TerrainType.NONE;
    private MapBoard mapController = default;

    public bool IsPassable { private set; get; } = false;
    public int TileIdx1D { private set; get; } = -1;
    public Vector2Int TileIdx2D { private set; get; } = default;

    #region ��ã�� �˰����� ���� ����
    private SpriteRenderer frontRenderer = default;
    private Color defaultColor = default;
    private Color selectedColor = default;
    private Color searchColor = default;
    private Color inactiveColor = default;
    #endregion  // ��ã�� �˰����� ���� ����

    private void Awake()
    {
        frontRenderer = gameObject.FindChildComponent<SpriteRenderer>(TILE_FRONT_RENDERER_OBJ_NAME);
        defaultColor = new Color(1f, 1f, 1f, 1f);
        selectedColor = new Color(236f / 255f, 130f / 255f, 20f / 255f, 1f);
        searchColor = new Color(0f, 192f / 255f, 0f, 1f);
        inactiveColor = new Color(128f / 255f, 128f / 255f, 128f / 255f, 1f);
    }

    //! ���� ������ �ʱ� �����Ѵ�.
    public void SetupTerrain(MapBoard mapController, TerrainType type, int tileIdx1D)
    {
        terrainType = type;
        this.mapController = mapController;
        TileIdx1D = tileIdx1D;
        TileIdx2D = mapController.GetTileIdx2D(tileIdx1D);

        string prefabName = string.Empty;
        switch (type)
        {
            case TerrainType.PLAIN_PASS:
                {
                    prefabName = RDefine.TERRAIN_PREF_PLAIN;
                    IsPassable = true;
                }
                break;

            case TerrainType.OCEAN_N_PASS:
                {
                    prefabName = RDefine.TERRAIN_PREF_OCEAN;
                    IsPassable = false;
                }
                break;
            default:
                {
                    prefabName = "Tile_Default";
                    IsPassable = false;
                }
                break;
        }       // switch: Ÿ���� Ÿ�Ժ��� �ٸ� ������ �Ѵ�.

        this.name = string.Format("{0}_{1}", prefabName, tileIdx1D);
    }   // SetupTerrain()

}
