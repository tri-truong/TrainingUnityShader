using UnityEngine;
using System.Collections;

public class EffectsGrayScale : MonoBehaviour {
	public Material mat;
	void OnRenderImage(RenderTexture src, RenderTexture dest){
		Graphics.Blit(src,dest,mat);
	}
}
