using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using System;
using System.Text;

namespace Hex.Arcanum.Lexer
{
   public sealed partial class Lexer
   {
		private readonly List<Lexeme> _lexemeList = new();

		public Lexer() { }

		public List<Lexeme> Run(string src)
		{
			_lexemeList.Clear();
			string[] lineList = SplitIntoLines(src);
			for (int i = 0; i < lineList.Length; i++)
				ProcessLine(lineList[i], i + 1);

			return _lexemeList;
		}

		public string[] SplitIntoLines(string str)
		{
			bool quoted = false;
			List<string> list = new();
			int start = 0;
			for (int idx = 0; idx < str.Length; idx++)
			{
				if (str[idx] == '\"')
					quoted = !quoted;
				else if ((str[idx] == '\r' || str[idx] == '\n') && !quoted)
				{
					list.Add(str.Substring(start, idx - start));
					if (str[idx] == '\r' && idx + 1 < str.Length && str[idx + 1] == '\n')
						idx++;

					start = idx + 1;
				}
			}

			if (start < str.Length)
				list.Add(str.Substring(start));

			return list.ToArray();
		}

		public void ProcessLine(string line, int lineNo)
		{
			LexerState ls = new(lineNo);
			Rune rune;

			var runeList = line.EnumerateRunes().ToArray();
			for (int idx = 0; idx < runeList.Length; idx++)
			{
				rune = runeList[idx];
				switch (ls.State)
				{
					default: throw new HexException($"Lexer entered invalid state {ls.State} on line {ls.Line}, col {ls.Col}");

					case kState_Idle:
						// NOTE: handled below
						break;

					case kState_Number:
						if (!IsNumber(rune))
							AddLexeme(ls, LexemeTypes.Number);
						break;

					case kState_String:
						if (rune == kDoubleQuote)
						{
							AddLexeme(ls, LexemeTypes.String);
							idx++;
							continue;
						}
						break;

					case kState_Identifier:
						if (!IsRune(rune))
							AddLexeme(ls, LexemeTypes.Identifier);
						break;
				}

				if (ls.State == kState_Idle)
				{
					if (IsNumber(rune))
						ls.SwitchTo(kState_Number, idx, rune);
					else if (IsRune(rune))
						ls.SwitchTo(kState_Identifier, idx, rune);
					else if (rune == kDoubleQuote)
						ls.SwitchTo(kState_String, idx, kEmptyRune);
					else if (!Rune.IsWhiteSpace(rune))
					{
						if (!_symbolMap.ContainsKey(rune.Value))
							throw new UnsupportedArcaneException(rune, lineNo, idx);

						_lexemeList.Add(new Lexeme(_symbolMap[rune.Value], rune.ToString(), lineNo, idx));
					}
				}
				else
					ls.Push(rune);
			}

			FinalizeLine(ls, line.Length);
		}

		public void FinalizeLine(LexerState ls, int len)
		{
			switch (ls.State)
			{
				default: throw new HexException($"Unknown exception occured processing line {ls.Line}");
				
				case kState_Idle:	break;   // NOTE: nothing to finish processing
				case kState_Number:
					AddLexeme(ls, LexemeTypes.Number);
					break;
				case kState_Identifier:
					AddLexeme(ls, LexemeTypes.Identifier);
					break;
				case kState_String:
					throw new HexException($"Unexpected end of line while parsing a string on line {ls.Line}");
			}
			_lexemeList.Add(new Lexeme(LexemeTypes.NewLine, kNewLine, ls.Line, len));
		}

		public void AddLexeme(LexerState ls, LexemeTypes lexType)
		{
			_lexemeList.Add(new Lexeme(lexType, ls.Value(), ls.Line, ls.Col));
			ls.Reset();
		}
	}
}
