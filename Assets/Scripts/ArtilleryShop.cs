using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryShop : MonoBehaviour
{
    public CannonBlueprint[] cannonBlueprints;

    TowerBuilder towerBuilder;

    private void Start()
    {
        towerBuilder = TowerBuilder.towerBuilderInstance;
    }


    public void SelectCannon(int cannonID)
    {
        towerBuilder.SelectCannonToBuild(cannonBlueprints[cannonID]);
    }





}
