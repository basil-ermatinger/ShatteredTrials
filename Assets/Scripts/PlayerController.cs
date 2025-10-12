using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rpg2dSidescroller
{
	public class PlayerController : MonoBehaviour
	{
		private Rigidbody _rb;
		private PlayerInputSet _input;
		private Vector2 _moveInput;

		public StateMachine PlayerStateMachine { get; private set; }

		private float _moveSpeed = 5f;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody>();

			_input = new PlayerInputSet();
			InitializeStateMachine();
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

		private void InitializeStateMachine()
		{
			IState playerIdleState = new PlayerIdleState(this);

			List<IState> playerStates = new List<IState>()
			{
				playerIdleState
			};

			PlayerStateMachine = new StateMachine(playerStates);
			PlayerStateMachine.Initialize(playerIdleState);
		}
	}
}
