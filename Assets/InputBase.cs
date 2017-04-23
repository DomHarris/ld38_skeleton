using UnityEngine;
using System.Collections;

[System.Serializable]
public enum PlayerEnum {
	p1_,
	p2_,
	p3_,
	p4_
}

public abstract class InputBase : MonoBehaviour
{
	protected bool isActive = true;
	[SerializeField] protected PlayerEnum player = PlayerEnum.p1_;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(GetInputs());
	}
	
	// Update is called once per frame
	IEnumerator GetInputs ()
	{
		while (isActive)
		{
			LeftHorizontal(Input.GetAxis(player + "LeftHorizontal"));
		
			LeftVertical(Input.GetAxis(player + "LeftVertical"));
		
			RightHorizontal(Input.GetAxis(player + "RightHorizontal"));
		
			RightVertical(Input.GetAxis(player + "RightVertical"));
			
			yield return new WaitForEndOfFrame();
		}
	}

	protected abstract void LeftHorizontal (float val);
	protected abstract void LeftVertical (float val);
	protected abstract void RightHorizontal (float val);
	protected abstract void RightVertical (float val);
}
