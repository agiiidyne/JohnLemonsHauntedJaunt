using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillOverTime : MonoBehaviour
{
    public Image cooldown;
	public float fillDuration = 7.0f;
	private bool hasCooldown;
	private bool isFilling = false;
	public float targetFillAmount = 1.0f;
	
	void Start()
	{
		cooldown.fillAmount = 0f;
		StartCoroutine(ActivateCooldown());
	}
	
	void Update()
	{
		if(Input.GetKey(KeyCode.Space) && !hasCooldown)
		{
			StartCoroutine(ActivateCooldown());
		}
	}
	
	IEnumerator ActivateCooldown()
	{
		hasCooldown = true;
		cooldown.fillAmount = 0f;
		yield return StartCoroutine(IncreaseFill());
		hasCooldown = false;
		cooldown.fillAmount = 1f;
	}
	
	IEnumerator IncreaseFill()
	{
		isFilling = true;
		float elapsedTime = 0f;
		float startFillAmount = 0f;
		
		while(elapsedTime < fillDuration)
		{
			float currentFillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, elapsedTime/fillDuration);
			cooldown.fillAmount = currentFillAmount;
			
			elapsedTime += Time.deltaTime;
			
			yield return null;
		}
		
		cooldown.fillAmount = targetFillAmount;
		
		isFilling = false;
	}
}
