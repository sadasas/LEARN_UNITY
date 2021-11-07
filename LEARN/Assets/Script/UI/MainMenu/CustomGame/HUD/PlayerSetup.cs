
using UnityEngine;

using UnityEngine.UI;
using ChooseUnit;


public class PlayerSetup : CustomGameManager
{

    [SerializeField] Transform pointSpawn, descriptionPanel;
   
    [SerializeField] Text unitName;

   
    //private
    ChooseUnitManager CUM;
    bool callback = false;


    private void Start()
    {
        CUM = new ChooseUnitManager(descriptionPanel, rh.unitDisplayPrefab, pointSpawn, unitName);
        ChooseUnit(0);
    }
    private void Update()
    {

        //descritpion input swicth 
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!callback)
            {
                callback = true;
                CUM.SwitchDesScreen();
            }
            else
            {
                callback = false;
                CUM.SwitchFullView();
            }
        }
    }




    public override void SaveSetting()
    {
        gameSetup.player.typeShoot = CUM.currentUnit.unitDes.typeShoot;
        gameSetup.player.typeUnit = CUM.currentUnit.unitDes.typeUnit;
        base.SaveSetting();
    }
    public override void InvokeSwitchMenu(int number)
    {
        base.InvokeSwitchMenu(number);
        CUM.DestroyCurrentUnit();
    }

    public override void PlayCustom()
    {
        base.PlayCustom();
    }


    

    public void ChooseUnit(int unit)
    {
        switch (unit)
        {
                case 0:
                CUM.SpawnUnit(0);
                break;
                case 1:
                CUM.SpawnUnit(1);
                break;
        }
    }

   



 
}
