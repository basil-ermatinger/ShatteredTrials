using UnityEngine;

public class Calculator
{
	public int AddNumbers(int numA, int numB)
	{
		return numA + numB;
	}

	public int DivideNumbers(int numA, int numB)
	{
		if(numB == 0)
		{
			Debug.LogError("Cannot divide by zero!");
			return 0;
		}

		return numA / numB;
	}

	public float GetPI()
	{
		return Mathf.PI;
	}
}
