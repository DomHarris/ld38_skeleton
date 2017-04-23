using UnityEngine;

public class InputHandler : InputBase
{
	[SerializeField] float speed = 5;
	[SerializeField] ParticleSystem ps; 

	float rightX = 0;
	float rightY = 0;
	protected override void LeftHorizontal (float val)
	{
		transform.position += Vector3.right * val * Time.deltaTime * speed;
	}
	protected override void LeftVertical (float val)
	{
		transform.position += Vector3.up * val * Time.deltaTime * speed;
	}
	protected override void RightHorizontal (float val)
	{
		rightX = val;
	}
	protected override void RightVertical (float val)
	{
		rightY = val;
	}


	void Update ()
	{
		if (rightX != 0 || rightY != 0)
		{
			ParticleSystem.EmitParams ep = new ParticleSystem.EmitParams();
			ep.velocity = new Vector3 (rightX, rightY) * 8;
			ep.position = transform.position;
			ep.startSize = 0.5f;
			ps.Emit(ep, 1);

		}
	}
}
