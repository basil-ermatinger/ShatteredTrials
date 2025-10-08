using System;
using UnityEngine;

namespace Rpg2dSidescroller
{
	public class Player : MonoBehaviour
	{
		private Rigidbody _rb;
		private PlayerInputSet _input;
		private Vector2 _moveInput;

		private float _moveSpeed = 5f;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody>();

			_input = new PlayerInputSet();
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
			_input.Enable();

			_input.Player.Movement.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
			_input.Player.Movement.canceled += ctx => _moveInput = Vector2.zero;
		}

		private void FixedUpdate()
		{
			SetVelocity(_moveInput.x, _moveInput.y);
		}

		private void OnDisable()
		{
			_input.Disable();
		}

		private void SetVelocity(float xVelocity, float zVelocity)
		{
			Vector3 move = new Vector3(xVelocity, 0f, zVelocity) * _moveSpeed;

			Debug.Log("Move: " + move);

			_rb.linearVelocity = new Vector3(move.x, _rb.linearVelocity.y, move.z);
		}
	}
}
