using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [SerializeField] Color highlightedColor;
    Color defaultColor;
    [SerializeField] Color bancruptColor;
    Renderer ren;

    [Header("Optional")]
    public GameObject cannon;

    TowerBuilder towerBuilder;


    private void Start()
    {
        ren = GetComponent<Renderer>();
        defaultColor = ren.material.color;
        towerBuilder = TowerBuilder.towerBuilderInstance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!towerBuilder.CanBuild)
        {
            return;
        }

        if (towerBuilder.HasMoney)
        {
            ren.material.color = highlightedColor;
        }
        else
        {
            ren.material.color = bancruptColor;
        }
        
    }

    private void OnMouseExit()
    {
        ren.material.color = defaultColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!towerBuilder.CanBuild)
        {
            return;
        }

        if(cannon != null)
        {
            return;
        }

        towerBuilder.BuildCannonOn(this);

    }

}
