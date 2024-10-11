using ASTInterpreter;
using System.Collections;

internal class Program
{
	private static void Main(string[] args)
	{
		test();
		test();
	}

	public static IEnumerable<int> test()
	{
		Console.WriteLine("run 1");
		yield return 1;
		Console.WriteLine("run 2");
		yield return 2;
	}
}

public class Corotine : IEnumerator<int>
{
	public int Current => throw new NotImplementedException();

	object IEnumerator.Current => throw new NotImplementedException();

	public void Dispose()
	{
		throw new NotImplementedException();
	}

	public bool MoveNext()
	{
		throw new NotImplementedException();
	}

	public void Reset()
	{
		throw new NotImplementedException();
	}
}