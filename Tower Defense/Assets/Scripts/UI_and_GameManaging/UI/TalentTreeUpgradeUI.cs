using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentTreeUpgradeUI : MonoBehaviour
{
    public bool isUnlocked;

    public ParticleSystem[] unlockedEffects;
    public ParticleSystem[] lockedEffects;

    public TalentTreeUpgradeUI[] upgradedSkill;

    public Color lockedColor;

    void Start()
    {
        if (!isUnlocked)
        {
            GetComponent<Image>().color = lockedColor;
            SetEffects();
            return;
        }
        else
        {
            for (int i = 0; i < upgradedSkill.Length; i++)
            {
                if(upgradedSkill[i] == null)
                {
                    return;
                }

                if (upgradedSkill[i].isUnlocked)
                {
                    unlockedEffects[i].Play();
                    lockedEffects[i].Stop();
                }
                else
                {
                    lockedEffects[i].Play();
                    unlockedEffects[i].Stop();
                }
            }
        }
    }

    private void SetEffects()
    {
        for (int i = 0; i < upgradedSkill.Length; i++)
        {
            if (upgradedSkill[i] == null)
            {
                return;
            }
            else
            {
                upgradedSkill[i].SetThisSkillInactive();
                unlockedEffects[i].Stop();
                lockedEffects[i].Stop();
            }
        }
    }

    public void SetThisSkillInactive()
    {
        for (int i = 0; i < upgradedSkill.Length; i++)
        {
            if (upgradedSkill[i] == null)
            {
                return;
            }
            else
            {
                upgradedSkill[i].SetThisSkillInactive();
            }
        }

        gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        Debug.Log("mouse detected");
        Debug.Log(Input.mousePosition);
    }
}
