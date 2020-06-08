using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("Colors")]
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;

    [Header("References")]
    public BuildManager buildManagerScript;

    // neccassary components
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public ScriptableTurret scriptableTurret;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(turret != null)
        {
            buildManagerScript.SetNode(this);
            return;
        }

        if (!buildManagerScript.CanBuild)
        {
            return;
        }

        BuildTurret(buildManagerScript.GetTurretToBuild());
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManagerScript.CanBuild)
        {
            return;
        }

        if (buildManagerScript.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void SellTurret()
    {
        if (isUpgraded)
        {
            PlayerStats.Money += scriptableTurret.upgradedTurretScriptableObject.GetSellAmount();
        }
        else
        {
            PlayerStats.Money += scriptableTurret.GetSellAmount();
        }

        isUpgraded = false;

        GameObject effect = (GameObject)Instantiate(buildManagerScript.sellTurretEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        scriptableTurret = null;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < scriptableTurret.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade");
            return;
        }

        PlayerStats.Money -= scriptableTurret.upgradeCost;

        // destroy old turret
        Destroy(turret);

        // instantiate upgraded turret
        GameObject _turret = (GameObject)Instantiate(scriptableTurret.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManagerScript.buildTurretEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
    }

    private void BuildTurret(ScriptableTurret currentScriptableTurret)
    {
        if (PlayerStats.Money < currentScriptableTurret.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        scriptableTurret = currentScriptableTurret;

        PlayerStats.Money -= currentScriptableTurret.cost;

        GameObject _turret = (GameObject)Instantiate(currentScriptableTurret.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManagerScript.buildTurretEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }
}
