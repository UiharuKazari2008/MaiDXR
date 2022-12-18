using TMPro;
using UnityEngine;
using uWindowCapture;
using UnityEngine.UI;

public class CaptureSettingManager : MonoBehaviour
{
    public GameObject CaptureDisplay;
    private UwcWindowTexture WindowTexture;
    private TMP_Dropdown Dropdown;
    private Toggle Toggle;
    void Start()
    {
        WindowTexture = CaptureDisplay.GetComponent<UwcWindowTexture>();
        Dropdown = GetComponent<TMP_Dropdown>();
        Toggle = GetComponent<Toggle>();
        switch (gameObject.name)
        {
            case "CPModeDropdown":
                GetCPMode();
                break;
            case "CPDesktop":
                GetCPDesktop();
                break;
            case "CPFPSDropdown":
                GetCPFPS();
                break;
        }
    }
    public void GetCPMode()
    {
        if (JsonConfig.HasKey("CaptureMode")) 
            Dropdown.value = JsonConfig.GetInt("CaptureMode");
        SetCPMode();
    }
    public void GetCPDesktop()
    {
        if (JsonConfig.HasKey("CaptureDesktop")) 
            Toggle.isOn = JsonConfig.GetBoolean("CaptureDesktop");
        SetCPDesktop();
    }
    public void GetCPFPS()
    {
        if (JsonConfig.HasKey("CaptureFPS")) 
            Dropdown.value = JsonConfig.GetInt("CaptureFPS");
        SetCPFPS();

    }

    public void SetCPMode()
    {
        WindowTexture.captureMode = (CaptureMode)Dropdown.value - 1;
        JsonConfig.SetInt("CaptureMode", Dropdown.value);
    }
    
    public void SetCPDesktop()
    {
        if (Toggle.isOn)
            WindowTexture.type = WindowTextureType.Desktop;
        else
            WindowTexture.type = WindowTextureType.Window;
        JsonConfig.SetBoolean("CaptureDesktop", Toggle.isOn);
    }
    
    public void SetCPFPS()
    {
        switch (Dropdown.value)
        {
            case 0:
                WindowTexture.captureFrameRate = 30;
                break;
            case 1:
                WindowTexture.captureFrameRate = 60;
                break; 
            case 2:
                WindowTexture.captureFrameRate = 72;
                break;
            case 3:
                WindowTexture.captureFrameRate = 90;
                break;
            case 4:
                WindowTexture.captureFrameRate = 120;
                break;
            case 5:
                WindowTexture.captureFrameRate = 144;
                break;
        }
        JsonConfig.SetInt("CaptureFPS", Dropdown.value);
    }
}
