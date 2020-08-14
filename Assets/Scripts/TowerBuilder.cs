using UnityEngine;

public class TowerBuilder : MonoBehaviour
{

    CannonBlueprint cannonToBuild;
    public static TowerBuilder towerBuilderInstance;
    
    public GameObject[] cannonModelPrefab;
    
    public bool CanBuild { get { return cannonToBuild != null; } }
    public bool HasMoney { get { return cannonToBuild.cost <= PlayerStats.Coins; } }


    void Awake()
    {
        towerBuilderInstance = this;
    }
    
    public void SelectCannonToBuild(CannonBlueprint cannonBlueprint)
    {
        cannonToBuild = cannonBlueprint;
    }

    public void BuildCannonOn(Tile tile)
    {
        if (PlayerStats.Coins < cannonToBuild.cost)
        {
            return;
        }

        PlayerStats.Coins -= cannonToBuild.cost;


        GameObject cannon = (GameObject)Instantiate(cannonToBuild.cannonModel, tile.transform.position + cannonToBuild.offset, Quaternion.identity);
        tile.cannon = cannon;
    }
}
