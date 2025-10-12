using Rpg2dSidescroller;
using System.Diagnostics;

namespace Rpg2dSidescroller
{
	public class PlayerIdleState : IState
	{
		private PlayerController _player;

		public PlayerIdleState(PlayerController player)
		{
			_player = player;
		}

		public void Enter()
		{
			Debug.WriteLine("Enter Player Idle State");
		}

		public void Update()
		{
			Debug.WriteLine("Update Player Idle State");
		}

		public void Exit()
		{
			Debug.WriteLine("Enter Player Idle State");
		}
	}
}
