
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MapSetup : CustomGameManager
{
    [SerializeField] Dropdown value;
    [SerializeField] VideoPlayer mapPreivew;


    private void Start()
    {
        if (gameSetup.map < 0) return;
        value.value = gameSetup.map-1;
    }

    private void Update()
    {
        PreviewMap();
       
    }

    public override void InvokeSwitchMenu(int number)
    {
        base.InvokeSwitchMenu(number);
    }

    public override void SaveSetting()
    {
        gameSetup.map = value.value + 1;
        base.SaveSetting();
    }
    void PreviewMap()
    {
        switch (value.value)
        {
            case 0:
                mapPreivew.clip = rh.mapPriviewVidio[0];
                break;
            case 1:
                mapPreivew.clip = rh.mapPriviewVidio[1];
                break;
        }

        mapPreivew.SetTargetAudioSource(0, this.transform.GetChild(6).GetComponent<AudioSource>());
    }
}
