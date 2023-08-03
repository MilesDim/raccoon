using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(AudioSource))]
class BackGroundMusic1 : MonoBehaviour
{
	private static BackGroundMusic1 instance = null;
	public static BackGroundMusic1 Instance
	{
		get
		{
			if (instance == null)
			{
				instance = (BackGroundMusic1)FindObjectOfType(typeof(BackGroundMusic1));
			}
			return instance;
		}
	}
	
	void Awake ()
	{
		if (Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}