using Godot;
using System;

public class Game4MathProblem
{
	const int MAX_NUMER_FOR_ADD_OR_SUBTRACT = 50;
	const int MAX_NUMER_FOR_MULTIPLICATION = 12;

	public int Number1 { get; set; }
	public int Number2 { get; set; }
	public MATHOPERATIONS Operation { get; set; }
	public string OperateSymbol { get; set; }
	public int result { get; set; }

	public enum MATHOPERATIONS
	{
		ADD, SUBTRACT, MULTIPLY, DIVIDE
	}

	public Game4MathProblem()
	{
		generateRandomMathProblem();
	}

	private Game4MathProblem generateRandomMathProblem()
	{
		Operation = getMathProblemTypeAtRandom();
		switch (Operation)
		{
			case MATHOPERATIONS.ADD:
				(Number1, Number2) = GenerateNumbersForAdd();
				result = Number1 + Number2;
				OperateSymbol = "+";
				break;
			case MATHOPERATIONS.SUBTRACT:
				(Number1, Number2) = GenerateNumbersForSubtract();
				result = Number1 - Number2;
				OperateSymbol = "-";
				break;
			case MATHOPERATIONS.MULTIPLY:
				(Number1, Number2) = GenerateNumbersForMultiply();
				result = Number1 * Number2;
				OperateSymbol = "*";
				break;
			case MATHOPERATIONS.DIVIDE:
				(Number1, Number2) = GenerateNumbersForDivide();
				result = Number1 / Number2;
				OperateSymbol = "/";
				break;
			default:
				break;
		}

		return this;
	}

	private MATHOPERATIONS getMathProblemTypeAtRandom()
	{
		Array values = Enum.GetValues(typeof(MATHOPERATIONS));
		Random random = new Random();
		return (MATHOPERATIONS)values.GetValue(random.Next(values.Length));
	}

	private (int, int) GenerateNumbersForAdd()
	{
		Random random = new Random();
		return (random.Next(1, MAX_NUMER_FOR_ADD_OR_SUBTRACT + 1), random.Next(1, MAX_NUMER_FOR_ADD_OR_SUBTRACT + 1));
	}
	private (int, int) GenerateNumbersForSubtract()
	{
		Random random = new Random();
		int firstNumber = random.Next(1, MAX_NUMER_FOR_ADD_OR_SUBTRACT + 1);
		int secondNumber = random.Next(1, firstNumber);
		return (firstNumber, secondNumber);
	}
	private (int, int) GenerateNumbersForMultiply()
	{
		Random random = new Random();
		return (random.Next(1, MAX_NUMER_FOR_MULTIPLICATION + 1), random.Next(1, MAX_NUMER_FOR_MULTIPLICATION + 1));
	}
	private (int, int) GenerateNumbersForDivide()
	{
		Random random = new Random();
		int secondNumber = random.Next(1, MAX_NUMER_FOR_MULTIPLICATION);
		int firstNumber = random.Next(1, MAX_NUMER_FOR_MULTIPLICATION) * secondNumber;
		return (firstNumber, secondNumber);
	}
}
