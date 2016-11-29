using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class timers : MonoBehaviour
{
	List<Text> m_timers;
	public RectTransform m_image;
	public RectTransform m_toggle;
	int seq = 0;

	void Start ()
	{
		m_timers = new List<Text>(GetComponentsInChildren<Text>());
	}
	
	void LateUpdate ()
	{
		foreach (var t in m_timers)
		{
			t.text = seq + "\n" +
				Time.realtimeSinceStartup;
		}

		seq = (seq + 1) % 1000;

		m_image.localPosition = Vector3.down * (10f + 10f * (seq % 6));

		if (Input.anyKeyDown)
		{
			m_toggle.gameObject.SetActive(!m_toggle.gameObject.activeSelf);
		}
	}
}
