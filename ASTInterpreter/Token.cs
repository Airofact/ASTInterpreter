using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTInterpreter
{
	public class Token
	{
		private TokenType type;
		private String lexeme;
		private Object? literal;
		private Position position;

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
		COMMA, DOT, MINUS, PLUS, SEMICOLON, SLASH, STAR, CARET,

		BANG, BANG_EQUAL,
		EQUAL, EQUAL_EQUAL,
		GREATER, GREATER_EQUAL,
		LESS, LESS_EQUAL,

		IDENTIFIER, STRING, NUMBER,

		EOF
	}
}
