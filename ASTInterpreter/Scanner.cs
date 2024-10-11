using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASTInterpreter
{
	public class Scanner
	{
		private int start;
		private int index;

		private int line;

		private String source;
		private List<Token> tokens;

		public Scanner(String source)
		{
			this.start = 0;
			this.index = 0;

			this.source = source;
			this.tokens = new List<Token>();
		}

		public List<Token> Scan()
		{
			Regex numberRegex = new Regex(@"\d+");
			Regex identifierRegex = new Regex(@"[a-zA-Z_][a-zA-Z0-9_]*");
			while (!IsAtEnd())
			{
				char current = Advance();
				switch (current)
				{
					case '\n': { break; }
					case ' ': { break; }
					case '(': { AppendToken(TokenType.LEFT_PAREN, null); break; }
					case ')': { AppendToken(TokenType.RIGHT_PAREN, null); break; }
					case '{': { AppendToken(TokenType.LEFT_BRACE, null); break; }
					case '}': { AppendToken(TokenType.RIGHT_BRACE, null); break; }
					case ',': { AppendToken(TokenType.COMMA, null); break; }
					
					case '.': { AppendToken(TokenType.DOT, null); break; }
					case '-': { AppendToken(TokenType.MINUS, null); break; }
					case '+': { AppendToken(TokenType.PLUS, null); break; }
					case ';': { AppendToken(TokenType.SEMICOLON, null); break; }
					case '*': { AppendToken(TokenType.STAR, null); break; }
					case '^': { AppendToken(TokenType.CARET, null); break; }
					
					case '/':
						{
						if (Peek() == '/')
							{
							while (current != '\n' && !IsAtEnd())
							{
								Advance();
							}
						}
						else
							{
							AppendToken(TokenType.SLASH, null);
						}
						break;
					}
					case '!':
						{
						if (Peek() == '=')
							{
							Advance();
							AppendToken(TokenType.BANG_EQUAL, null);
						}
						else
							{
							AppendToken(TokenType.BANG, null);
						}
						break;
					}
					default:
						if (char.IsDigit(current))
						{
							StringBuilder sb = new();
							while (char.IsDigit(Peek()))
							{
								sb.Append(Advance());
							}
						}
						break;
				}
			}
			AppendToken(TokenType.EOF, null);
			return tokens;
		}

		public bool IsAtEnd()
		{
			return index >= source.Length;
		}

		public void AppendToken(TokenType type, Object? literal)
		{
			String text = source.Substring(start, index - start);
			tokens.Add(new Token(type, text, literal, new Position(line, start)));
		}

		public char Advance()
		{
			return source[index++];
		}

		public char Peek()
		{
			return source[index];
		}

		public char Peek2()
		{
			return source[index + 1];
		}

	}
}
