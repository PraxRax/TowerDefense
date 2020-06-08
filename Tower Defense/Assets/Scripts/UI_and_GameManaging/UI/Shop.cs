using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ScriptableTurret standardTurret;
    public ScriptableTurret missleTurret;
    public ScriptableTurret laserTurret;

    public Text standardTurretText;
    public Text missleTurretText;
    public Text laserTurretText;

    public BuildManager buildManagerScript;

    void Start()
    {
        standardTurretText.text = "$" + standardTurret.cost.ToString();
        missleTurretText.text = "$" + missleTurret.cost.ToString();
        laserTurretText.text = "$" + laserTurret.cost.ToString();
    }

    public void SelectStandardTurret()
    {
        buildManagerScript.SetTurretToBuild(standardTurret);
    }

    public void SelectMissleTurret()
    {
        buildManagerScript.SetTurretToBuild(missleTurret);
    }

    public void SelectLaserTurret()
    {
        buildManagerScript.SetTurretToBuild(laserTurret);
    }
}
