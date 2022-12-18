using System.IO;
using UnityEngine;
 
public class CameraImage : MonoBehaviour
{
    public Camera _camera;
    RenderTexture tempRT;

    void Start()
    {
        if (!Directory.Exists(Path.Combine(Application.dataPath, "../Camera")))
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "../Camera"));
        tempRT = new RenderTexture(1440, 1920, 24, RenderTextureFormat.ARGB32);
    }

    private void LateUpdate()
    {

    }

    public void Capture()
    {
        RenderTexture originalText = _camera.targetTexture;
        _camera.targetTexture = tempRT;
        RenderTexture.active = tempRT;
        _camera.Render();
        _camera.targetTexture = originalText;

        Texture2D image = new Texture2D(1440, 1920, TextureFormat.ARGB32, false, true);
        image.ReadPixels(new Rect(0, 0, image.width, image.height), 0, 0);
        image.Apply();

        RenderTexture.active = null;
        byte[] bytes = image.EncodeToPNG();


        string FileName = System.String.Format("WACCA-{0}.jpg",
                                System.DateTime.UtcNow.ToString("yyyyMMdd-HHmmss"));
        string FullPath = Path.Combine(Application.dataPath, "../Camera/", FileName);
        
        File.WriteAllBytes(FullPath, bytes);

        Debug.Log(System.String.Format("Image Saved to {0}", FullPath));
    }
}
