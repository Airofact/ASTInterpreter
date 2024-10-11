using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTInterpreter
{
	public class Token
	{
		private readonly TokenType type;
		private readonly String lexeme;
		private readonly Object? literal;
		private readonly Position position;

		public Token(TokenType type, String lexeme, Object? literal, Position position)
		{
			this.type = type;
			this.lexeme = lexeme;
			this.literal = literal;
			this.position = position;
		}
	}

	public enum TokenType
	{
		LEFT_PAREN, RIGHT_PAREN, LEFT_BRACE, RIGHT_BRACE,
		COMMA, DOT, SEMICOLON, 

		MINUS, MINUS_EQUAL,
		PLUS, PLUS_EQUAL,
		SLASH, SLASH_EQUAL,
		STAR, STAR_EQUAL,

		BANG, BANG_EQUAL,
		EQUAL, EQUAL_EQUAL,
		GREATER, GREATER_EQUAL,
		LESS, LESS_EQUAL,

		IDENTIFIER, STRING, NUMBER,

		FUNCTION, CLASS, LOCAL, CONST, IF, ELSE, WHILE, FOR, RETURN, BREAK, CONTINUE, TRUE, FALSE, NIL,

		EOF
	}
}
