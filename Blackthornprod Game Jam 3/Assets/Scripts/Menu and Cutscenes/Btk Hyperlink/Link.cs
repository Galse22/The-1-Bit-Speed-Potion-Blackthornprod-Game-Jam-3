using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public void OpenYT()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.youtube.com/channel/UCBgA6tSAxLkdLJVAILqZLuQ");
		#endif
	}
	public void OpenTwitter()
	{
		#if !UNITY_EDITOR
		openWindow("https://twitter.com/galse22");
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}