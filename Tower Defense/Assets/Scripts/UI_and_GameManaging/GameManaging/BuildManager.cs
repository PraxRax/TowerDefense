using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject buildTurretEffect;
    public GameObject sellTurretEffect;

    private ScriptableTurret turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SetNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SetTurretToBuild(ScriptableTurret turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

    public ScriptableTurret GetTurretToBuild()
    {
        return turretToBuild;
    }
}
