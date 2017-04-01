using UnityEngine;
using System.Collections;

public class CameraGrayScale : MonoBehaviour {
 	public Material mat;
    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src, dest, mat);
    }
	
}
