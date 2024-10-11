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

		public void moveLeft()
		{
			column--;
		}
		public void moveRight()
		{
			column++;
		}
		public void moveUp()
		{
			line--;
		}
		public void moveDown()
		{
			line++;
		}
	}
}
