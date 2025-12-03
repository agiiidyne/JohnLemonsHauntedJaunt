using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
	public float boostCooldown = 5f;
	public float boostDuration = 3f;
	private float speedBoost = 3;
	
	private bool hasCooldown;
	private Vector3 normalMovementVector;
	private Vector3 currentMovementVector;
	
	void Start ()
	{
		StartCoroutine(ActivateCooldown());
	}
	
	void Update ()
	{
		if(Input.GetKey(KeyCode.Space) && !hasCooldown)
		{
			currentMovementVector += Vector3.forward * speedBoost;
			StartCoroutine(ActivateCooldown());
			StartCoroutine(ResetMovementVector());
		}
		transform.Translate(currentMovementVector * Time.deltaTime);
	}
	
	IEnumerator ResetMovementVector()
	{
		yield return new WaitForSeconds(boostDuration);
		currentMovementVector = normalMovementVector;
		Debug.Log("boost ended");
	}
	
	IEnumerator ActivateCooldown ()
	{
		hasCooldown = true;
		yield return new WaitForSeconds(boostCooldown);
		hasCooldown = false;
		Debug.Log("boost ready");
	}
}
