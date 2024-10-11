using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTInterpreter
{
	public class Position
	{
		public int line;
		public int column;

		public Position(int line, int column)
		{
			this.line = line;
			this.column = column;
		}

		public void MoveLeft()
		{
			column--;
		}
		public void MoveRight()
		{
			column++;
		}
		public void MoveUp()
		{
			line--;
		}
		public void MoveDown()
		{
			line++;
		}
	}
}
