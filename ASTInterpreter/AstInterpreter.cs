

using Microsoft.Extensions.Logging;

namespace ASTInterpreter
{
	public class Ast
	{
		public static void Main(string[] args)
		{
			string input = """
				local sum = 114514;
				while(sum > 9961){
					sum -= 1
				}
				local output = "nmsl"
				""";
			Scanner scanner = new(input);
			List<Token> tokens = scanner.Scan();
			Logger.Info("scanning finished");
		}
	}
}