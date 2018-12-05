﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedoObjHealth : MonoBehaviour {

	public FloatData MaxHealth;
	public FloatData MinHealth;
	public FloatData StartHealth;
	public float CurrentHealth;
	public Sprite Dead01;
	public Sprite Dead02;

	public UnityEvent DeathEvent; 
	// Use this for initialization
	private void Start ()
	{
		CurrentHealth = StartHealth.Value;
	}

	private void Update()
	{
		ZeroHealth();
	}

	public void DamageHealth(float damage)
	{
		if (CurrentHealth > MinHealth.Value)
		{
			CurrentHealth -= damage;
		}
	}

	public void HealHealth(float heal)
	{
		if (CurrentHealth < MaxHealth.Value)
		{
			CurrentHealth += heal;
		}
	}

	public void ZeroHealth()
	{
		if (CurrentHealth <= MinHealth.Value)
		{
			//die
			gameObject.GetComponent<BoxCollider>().enabled = false;
			
			if (gameObject.GetComponent<CharacterController>())
			{
				gameObject.GetComponent<CharacterController>().enabled = false;
			}

			if (gameObject.GetComponent<Rigidbody>() != null)
			{
				gameObject.GetComponent<Rigidbody>().freezeRotation = false;
			}

			if (Dead01)
			{
				gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Dead01;
				StartCoroutine("ChangeDeathSprite");
			}

			gameObject.GetComponent<RedoObjHealth>().enabled = false;
			
			DeathEvent.Invoke();
		}
		
	}

	IEnumerator ChangeDeathSprite()
	{
		yield return new WaitForSeconds(1);
		gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Dead02;
	}
}
/*

public class ObjectHealth : MonoBehaviour
{
	public FloatData MaxHealth;
	public FloatData MinHealth;
	public FloatData StartHealth;
	public float CurrentHealth;



	public Sprite Dead01;

	public Sprite Dead02;
	//public GameObject Dead01;
	//public GameObject Dead02;

	// Use this for initialization
	private void Start()
	{
		CurrentHealth = StartHealth.Value;
	}

	private void Update()
	{
		ZeroHealth();
	}

	public void DamageHealth(float damage)
	{
		if (CurrentHealth > MinHealth.Value)
		{
			CurrentHealth -= damage;
		}
	}

	public void HealHealth(float heal)
	{
		if (CurrentHealth < MaxHealth.Value)
		{
			CurrentHealth += heal;
		}
	}

	public void ZeroHealth()
	{
		if (CurrentHealth <= MinHealth.Value)
		{
			//die
			gameObject.GetComponent<BoxCollider>().enabled = false;

			if (gameObject.GetComponent<CharacterController>())
			{
				gameObject.GetComponent<CharacterController>().enabled = false;
			}

			if (gameObject.GetComponent<Rigidbody>() != null)
			{
				gameObject.GetComponent<Rigidbody>().freezeRotation = false;
			}

			if (Dead01)
			{
				gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Dead01;
				//StartCoroutine(SpawnSprite());
			}

			gameObject.GetComponent<ObjectHealth>().enabled = false;
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	//IEnumerator SpawnSprite()
	//{
	//GameObject DeathObject01;
	//GameObject Deathobject02;

	//yield return new WaitForSeconds(1);
	//DeathObject01 = Instantiate(Dead01, transform.position, Quaternion.identity);
	//Destroy(DeathObject01, 1);
	//yield return new WaitForSeconds(1);
	//Deathobject02 = Instantiate(Dead02, transform.position, Quaternion.identity);
	//Destroy(Deathobject02, 1);
//}

	IEnumerator ChangeDeathSprite()
	{
		yield return new WaitForSeconds(1);
		gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Dead02;
	}
}
*/
