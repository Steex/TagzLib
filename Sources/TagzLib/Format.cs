using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Tagz
{
	public class Format
	{
		private class TagzKeyPrinter : TagzBaseListener
		{
			// override default listener behavior
			public override void EnterEveryRule(ParserRuleContext context)
			{
				base.EnterEveryRule(context);
				Console.WriteLine("rule: " + context.RuleIndex);
			}

			public override void VisitTerminal(ITerminalNode node)
			{
				base.VisitTerminal(node);
				Console.WriteLine("term: " + node.ToString());
			}
		}

		public void TestGrammar()
		{
			String input = "hello zome\r\nhello tezt";
			AntlrInputStream stream = new AntlrInputStream(input);
			ITokenSource lexer = new TagzLexer(stream);
			ITokenStream tokens = new CommonTokenStream(lexer);
			TagzParser parser = new TagzParser(tokens);
			parser.BuildParseTree = true;
			IParseTree tree = parser.r();
			TagzKeyPrinter printer = new TagzKeyPrinter();
			ParseTreeWalker.Default.Walk(printer, tree);
		}

		public string Do(string template)
		{
			return "==" + template + "==";
		}
	}
}
