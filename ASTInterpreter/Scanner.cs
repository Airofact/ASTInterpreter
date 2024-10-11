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

		private readonly String source;
		private readonly List<Token> tokens;

		public Scanner(String source)
		{
			this.start = 0;
			this.index = 0;

			this.source = source;
			this.tokens = new List<Token>();
		}

		public List<Token> Scan()
		{
			while (!IsAtEnd())
			{
				char current = Advance();
				switch (current)
				{
					case '\n':
						{
							line++;
							start = index;
							break;
						}
					case ' ': { break; }
					case '(': { AppendToken(TokenType.LEFT_PAREN, null); break; }
					case ')': { AppendToken(TokenType.RIGHT_PAREN, null); break; }
					case '{': { AppendToken(TokenType.LEFT_BRACE, null); break; }
					case '}': { AppendToken(TokenType.RIGHT_BRACE, null); break; }
					case ',': { AppendToken(TokenType.COMMA, null); break; }
					case '.': { AppendToken(TokenType.DOT, null); break; }
					case ';': { AppendToken(TokenType.SEMICOLON, null); break; }

					case '-':
						{
							if (Peek() == '=')
							{
								Advance();
								AppendToken(TokenType.MINUS_EQUAL, null);
							}
							else
							{
								AppendToken(TokenType.MINUS, null);
							}
							break;
						}
					case '+':
						{
							if(Peek() == '=')
							{
								Advance();
								AppendToken(TokenType.PLUS_EQUAL, null);
							}
							else
							{
								AppendToken(TokenType.PLUS, null);
							}
							break;
						}
					case '*':
						{
							if (Peek() == '=')
							{
								Advance();
								AppendToken(TokenType.STAR_EQUAL, null);
							}
							else
							{
								AppendToken(TokenType.STAR, null);
							}
							break;
						}
					case '/':
						{
							if (Peek() == '=')
							{
								Advance();
								AppendToken(TokenType.SLASH_EQUAL, null);
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
					case '=':
						{
						if (Peek() == '=')
							{
							Advance();
							AppendToken(TokenType.EQUAL_EQUAL, null);
						}
						else
							{
							AppendToken(TokenType.EQUAL, null);
						}
						break;
					}
					case '>':
						{
						if (Peek() == '=')
							{
							Advance();
							AppendToken(TokenType.GREATER_EQUAL, null);
						}
						else
							{
							AppendToken(TokenType.GREATER, null);
						}
						break;
					}
					case '<':
						{
						if (Peek() == '=')
							{
							Advance();
							AppendToken(TokenType.LESS_EQUAL, null);
						}
						else
							{
							AppendToken(TokenType.LESS, null);
						}
						break;
					}
					default:
						if (CanConsistNumber(current))
						{
							StringBuilder sb = new();
							sb.Append(current);
							while (CanConsistNumber(Peek()))
							{
								current = Advance();
								if (!CanConsistNumber(current))
								{
									Logger.Error("Identifier cannot start number");
								}
								sb.Append(current);
							}
							AppendToken(TokenType.NUMBER, sb.ToString());
						}
						else if (CanBeStringHead(current))
						{
							char head = current;
							StringBuilder sb = new();
							while (!DoPairedWithStringHead(head, Peek()))
							{
								sb.Append(Advance());
							}
							//pop the right quote
							Advance();
							AppendToken(TokenType.STRING, sb.ToString());
						}
						else if(CanBeIdentifiersFirstChar(current))
						{
							StringBuilder sb = new();
							sb.Append(current);
							while (CanConsistIdentifier(Peek()))
							{
								sb.Append(Advance());
							}
							string identifier = sb.ToString();
							switch (identifier)
							{
								case "function": { AppendToken(TokenType.FUNCTION, null); break; }
								case "class": { AppendToken(TokenType.CLASS, null); break; }
								case "local": { AppendToken(TokenType.LOCAL, null); break; }
								case "const": { AppendToken(TokenType.CONST, null); break; }
								case "if": { AppendToken(TokenType.IF, null); break; }
								case "else": { AppendToken(TokenType.ELSE, null); break; }
								case "while": { AppendToken(TokenType.WHILE, null); break; }
								case "for": { AppendToken(TokenType.FOR, null); break; }
								case "return": { AppendToken(TokenType.RETURN, null); break; }
								case "break": { AppendToken(TokenType.BREAK, null); break; }
								case "continue": { AppendToken(TokenType.CONTINUE, null); break; }
								case "true": { AppendToken(TokenType.TRUE, true); break; }
								case "false": { AppendToken(TokenType.FALSE, false); break; }
								case "nil": { AppendToken(TokenType.NIL, null); break; }
								default: {
									AppendToken(TokenType.IDENTIFIER, identifier);
									break;
								}
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
			String text = source[start..index];
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

		private static bool CanConsistNumber(char c)
		{
			return char.IsDigit(c);
		}

		private static bool CanBeIdentifiersFirstChar(char c)
		{
			return char.IsLetter(c) || c == '_';
		}

		private static bool CanConsistIdentifier(char c)
		{
			return char.IsLetterOrDigit(c) || c == '_';
		}

		private static bool CanBeStringHead(char c)
		{
			return c == '"' || c == '\'';
		}
		private static bool DoPairedWithStringHead(char head, char c)
		{
			return c == head;
		}
	}
}
