
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace ChooseUnit
{

    public class ChooseUnitManager
    {

        Transform descriptionPanel;
        GameObject[] unitPrefab;
        Transform pointSpawn;
        Text unitName;



        public UnitDesrciption currentUnit { get; set; }


        int id;

        public ChooseUnitManager(Transform _descriptionPanel, GameObject[] _unitPrefab, Transform _pointSpawn, Text _unitname)
        {
            this.descriptionPanel = _descriptionPanel;
            this.unitPrefab = _unitPrefab;
            this.pointSpawn = _pointSpawn;
            this.unitName = _unitname;

        }

        public void Starting()
        {

        }

        public UnitDesrciption SwitchDesScreen()
        {
            if (currentUnit != null) DestroyCurrentUnit();
            descriptionPanel.gameObject.SetActive(true);
            descriptionPanel.GetChild(0).GetComponent<Text>().text = currentUnit.unitDes.name;
            descriptionPanel.GetChild(1).GetComponent<Text>().text = currentUnit.unitDes.ability;
            descriptionPanel.GetChild(2).GetComponent<Text>().text = currentUnit.unitDes.skill;
            return currentUnit;
        }

        public GameObject SwitchFullView()
        {
            descriptionPanel.gameObject.SetActive(false);
            return SpawnUnit(id);
        }
        public GameObject SpawnUnit(int unit)
        {
            id = unit;
            descriptionPanel.gameObject.SetActive(false);
            if (currentUnit != null) DestroyCurrentUnit();
            GameObject unitDisplay;
            switch (unit)
            {
                case 0:
                    unitDisplay = GameObject.Instantiate(unitPrefab[0], pointSpawn.position, pointSpawn.rotation);
                    currentUnit = unitDisplay.GetComponent<UnitDesrciption>();
                    unitName.text = currentUnit.unitDes.name;
                    break;
                case 1:
                    unitDisplay = GameObject.Instantiate(unitPrefab[1], pointSpawn.position, pointSpawn.rotation);
                    currentUnit = unitDisplay.GetComponent<UnitDesrciption>();
                    unitName.text = currentUnit.unitDes.name;
                    break;
            }
           

            return currentUnit.gameObject;
        }

        public void DestroyCurrentUnit()
        {
            GameObject.Destroy(currentUnit.gameObject);
        }
    }

}

