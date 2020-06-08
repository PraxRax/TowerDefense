using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public TextMeshProUGUI upgradeCost;

    public TextMeshProUGUI sellAmount;

    public Button upgradeButton;

    public BuildManager BuildManagerScript;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.scriptableTurret.upgradeCost.ToString();
            upgradeButton.interactable = true;

            sellAmount.text = "$" + _target.scriptableTurret.GetSellAmount().ToString();
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;

            sellAmount.text = "$" + _target.scriptableTurret.upgradedTurretScriptableObject.GetSellAmount().ToString();
        }

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManagerScript.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManagerScript.DeselectNode();
    }
}
