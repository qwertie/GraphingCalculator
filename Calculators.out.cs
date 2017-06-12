// Generated from Calculators.ecs by LeMP custom tool. LeMP version: 2.5.2.0
// Note: you can give command-line arguments to the tool via 'Custom Tool Namespace':
// --no-out-header       Suppress this message
// --verbose             Allow verbose messages (shown by VS as 'warnings')
// --timeout=X           Abort processing thread after X seconds (default: 10)
// --macros=FileName.dll Load macros from FileName.dll, path relative to this file 
// Use #importMacros to use macros in a given namespace, e.g. #importMacros(Loyc.LLPG);
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loyc;
using Loyc.Syntax;
using Loyc.Collections;
namespace LesGraphingCalc
{
	using number = System.Double;	// Change this line to make a calculator for a different data type 
	class CalcRange {
		public number Lo;
		public number Hi;
		public int PxCount;
		// Generate a constructor and three public fields
		public CalcRange(number lo, number hi, int pxCount)
		{
			Lo = lo;
			Hi = hi;
			PxCount = pxCount;
			StepSize = (Hi - Lo) / Math.Max(PxCount - 1, 1);
		}
		public number StepSize;
		public number ValueToPx(number value) => (value - Lo) / (Hi - Lo) * PxCount;
		public number PxToValue(int px) => (number) px / PxCount * (Hi - Lo) + Lo;
		public number PxToDelta(int px) => (number) px / PxCount * (Hi - Lo);
		public CalcRange DraggedBy(int dPx) => 
		new CalcRange(Lo - PxToDelta(dPx), Hi - PxToDelta(dPx), PxCount);
		public CalcRange ZoomedBy(number ratio)
		{
			double mid = (Hi + Lo) / 2, halfSpan = (Hi - Lo) * ratio / 2;
			return new CalcRange(mid - halfSpan, mid + halfSpan, PxCount);
		}
	}

	// "alt class" generates an entire class hierarchy with base class CalculatorCore and 
	// read-only fields. Each "alternative" (derived class) is marked with the word "alt".
	abstract class CalculatorCore {
		static readonly Symbol sy_x = (Symbol) "x", sy_y = (Symbol) "y";
		// Base class constructor and fields
		public CalculatorCore(LNode Expr, Dictionary<Symbol, LNode> Vars, CalcRange XRange) {
			this.Expr = Expr;
			this.Vars = Vars;
			this.XRange = XRange;
		}
	
		public LNode Expr { get; private set; }
		public Dictionary<Symbol, LNode> Vars { get; private set; }
		public CalcRange XRange { get; private set; }
		public abstract CalculatorCore WithExpr(LNode newValue);
		public abstract CalculatorCore WithVars(Dictionary<Symbol, LNode> newValue);
		public abstract CalculatorCore WithXRange(CalcRange newValue);
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)] public LNode Item1 {
			get {
				return Expr;
			}
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)] public Dictionary<Symbol, LNode> Item2 {
			get {
				return Vars;
			}
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)] public CalcRange Item3 {
			get {
				return XRange;
			}
		}
		public object Results { get; protected set; }
	
		public abstract object Run();
		public abstract number? GetValueAt(int x, int y);
	
		public static CalculatorCore New(LNode expr, Dictionary<Symbol, LNode> vars, CalcRange xRange, CalcRange yRange)
		{
			// Find out if the expression uses the variable "y" (or is an equation with '=' or '==')
			// As an (unnecessary) side effect, this throws if an unreferenced var is used
			bool isEquation = expr.Calls(CodeSymbols.Assign, 2) || expr.Calls(CodeSymbols.Eq, 2), usesY = false;
			if (!isEquation) {
				LNode zero = LNode.Literal((double) 0);
				Func<Symbol, double> lookup = null;
				lookup = name => name == sy_x || (usesY |= name == sy_y) ? 0 : Eval(vars[name], lookup);
				Eval(expr, lookup);
			}
			if (isEquation || usesY)
				return new Calculator3D(expr, vars, xRange, yRange);
			else
				return new Calculator2D(expr, vars, xRange);
		}
	
		// Parse the list of variables provided in the GUI
		public static Dictionary<Symbol, LNode> ParseVarList(IEnumerable<LNode> varList)
		{
			var vars = new Dictionary<Symbol, LNode>();
			foreach (LNode assignment in varList) {
				{
					LNode expr, @var;
					if (assignment.Calls(CodeSymbols.Assign, 2) && (@var = assignment.Args[0]) != null && (expr = assignment.Args[1]) != null) {
						if (!@var.IsId)
							throw new ArgumentException("Left-hand side of '=' must be a variable name: {0}".Localized(@var));
					
						// For efficiency, try to evaluate the expression in advance
						try { expr = LNode.Literal(Eval(expr, vars)); } catch { }	// it won't work if expression uses X or Y
						vars.Add(@var.Name, expr);
					} else
						throw new ArgumentException("Expected assignment expression: {0}".Localized(assignment));
				} ;
			}
			return vars;
		}
	
		public static number Eval(LNode expr, Dictionary<Symbol, LNode> vars)
		{
			Func<Symbol, number> lookup = null;
			lookup = name => Eval(vars[name], lookup);
			return Eval(expr, lookup);
		}
	
		// Evaluates an expression
		public static number Eval(LNode expr, Func<Symbol, number> lookup)
		{
			if (expr.IsLiteral) {
				if (expr.Value is number)
					return (number) expr.Value;
				else
					return (number) Convert.ToDouble(expr.Value);
			}
			if (expr.IsId)
				return lookup(expr.Name);
		
			// expr must be a function or operator
			if (expr.ArgCount == 2) {
				{
					LNode a, b, hi, lo, tmp_10, tmp_11 = null;
					if (expr.Calls(CodeSymbols.Add, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) + Eval(b, lookup);
					else if (expr.Calls(CodeSymbols.Mul, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) * Eval(b, lookup);
					else if (expr.Calls(CodeSymbols.Sub, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) - Eval(b, lookup);
					else if (expr.Calls(CodeSymbols.Div, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) / Eval(b, lookup);
					else if (expr.Calls(CodeSymbols.Mod, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) % Eval(b, lookup);
					else if (expr.Calls(CodeSymbols.Exp, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return (number) Math.Pow(Eval(a, lookup), Eval(b, lookup));
					else if (expr.Calls(CodeSymbols.Shr, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return (number) G.ShiftRight(Eval(a, lookup), (int) Eval(b, lookup));
					else if (expr.Calls(CodeSymbols.Shl, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return (number) G.ShiftLeft(Eval(a, lookup), (int) Eval(b, lookup));
					else if (expr.Calls(CodeSymbols.GT, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) > Eval(b, lookup) ? (number) 1 : (number) 0;
					else if (expr.Calls(CodeSymbols.LT, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) < Eval(b, lookup) ? (number) 1 : (number) 0;
					else if (expr.Calls(CodeSymbols.GE, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) >= Eval(b, lookup) ? (number) 1 : (number) 0;
					else if (expr.Calls(CodeSymbols.LE, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) <= Eval(b, lookup) ? (number) 1 : (number) 0;
					else if (expr.Calls(CodeSymbols.Eq, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) == Eval(b, lookup) ? (number) 1 : (number) 0;
					else if (expr.Calls(CodeSymbols.Neq, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) != Eval(b, lookup) ? (number) 1 : (number) 0;
					else if (expr.Calls(CodeSymbols.AndBits, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return (number) ((long) Eval(a, lookup) & (long) Eval(b, lookup));
					else if (expr.Calls(CodeSymbols.OrBits, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return (number) ((long) Eval(a, lookup) | (long) Eval(b, lookup));
					else if (expr.Calls(CodeSymbols.NullCoalesce, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) {
						var a2 = Eval(a, lookup); return double.IsNaN(a2) | double.IsInfinity(a2) ? Eval(b, lookup) : a2;
					} else if (expr.Calls(CodeSymbols.And, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null || expr.Calls((Symbol) "'and", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) != (number) 0 ? Eval(b, lookup) : (number) 0;
					else if (expr.Calls(CodeSymbols.Or, 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null || expr.Calls((Symbol) "'or", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Eval(a, lookup) == (number) 0 ? Eval(b, lookup) : (number) 1;
					else if (expr.Calls((Symbol) "'xor", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return (Eval(a, lookup) != 0) != (Eval(b, lookup) != 0) ? (number) 1 : (number) 0;
					else if (expr.Calls((Symbol) "xor", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return (number) ((long) Eval(a, lookup) ^ (long) Eval(b, lookup));
					else if (expr.Calls((Symbol) "min", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Math.Min(Eval(a, lookup), Eval(b, lookup));
					else if (expr.Calls((Symbol) "max", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Math.Max(Eval(a, lookup), Eval(b, lookup));
					else if (expr.Calls((Symbol) "mod", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null || expr.Calls((Symbol) "'MOD", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Mod(Eval(a, lookup), Eval(b, lookup));
					else if (expr.Calls((Symbol) "atan", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Math.Atan2(Eval(a, lookup), Eval(b, lookup));
					else if (expr.Calls((Symbol) "log", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return Math.Log(Eval(a, lookup), Eval(b, lookup));
					else if (expr.Calls((Symbol) "'in", 2) && (a = expr.Args[0]) != null && (tmp_10 = expr.Args[1]) != null && tmp_10.Calls(CodeSymbols.Tuple, 2) && (lo = tmp_10.Args[0]) != null && (hi = tmp_10.Args[1]) != null) return G.IsInRange(Eval(a, lookup), Eval(lo, lookup), Eval(hi, lookup)) ? (number) 1 : (number) 0;
					else if (expr.Calls((Symbol) "'clamp", 2) && (a = expr.Args[0]) != null && (tmp_11 = expr.Args[1]) != null && tmp_11.Calls(CodeSymbols.Tuple, 2) && (lo = tmp_11.Args[0]) != null && (hi = tmp_11.Args[1]) != null || expr.Calls((Symbol) "clamp", 3) && (a = expr.Args[0]) != null && (lo = expr.Args[1]) != null && (hi = expr.Args[2]) != null) return G.PutInRange(Eval(a, lookup), Eval(lo, lookup), Eval(hi, lookup));
					else if (expr.Calls((Symbol) "'P", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null || expr.Calls((Symbol) "P", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return P((int) Math.Round(Eval(a, lookup)), (int) Math.Round(Eval(b, lookup)));
					else if (expr.Calls((Symbol) "'C", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null || expr.Calls((Symbol) "C", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return C((ulong) Math.Round(Eval(a, lookup)), (ulong) Math.Round(Eval(b, lookup)));
				}
			}
			{
				LNode a, b, c, tmp_12;
				if (expr.Calls(CodeSymbols.Sub, 1) && (a = expr.Args[0]) != null) return -Eval(a, lookup);
				else if (expr.Calls(CodeSymbols.Add, 1) && (a = expr.Args[0]) != null) return Math.Abs(Eval(a, lookup));
				else if (expr.Calls(CodeSymbols.Not, 1) && (a = expr.Args[0]) != null) return Eval(a, lookup) == 0 ? (number) 1 : (number) 0;
				else if (expr.Calls(CodeSymbols.NotBits, 1) && (a = expr.Args[0]) != null) return (number) ~(long) Eval(a, lookup);
				else if (expr.Calls(CodeSymbols.QuestionMark, 2) && (c = expr.Args[0]) != null && (tmp_12 = expr.Args[1]) != null && tmp_12.Calls(CodeSymbols.Colon, 2) && (a = tmp_12.Args[0]) != null && (b = tmp_12.Args[1]) != null)
					return Eval(c, lookup) != (number) 0 ? Eval(a, lookup) : Eval(b, lookup);
				else if (expr.Calls((Symbol) "square", 1) && (a = expr.Args[0]) != null) {
					var n = Eval(a, lookup); return n * n;
				} else if (expr.Calls((Symbol) "sqrt", 1) && (a = expr.Args[0]) != null) return Math.Sqrt(Eval(a, lookup));
				else if (expr.Calls((Symbol) "sin", 1) && (a = expr.Args[0]) != null) return Math.Sin(Eval(a, lookup));
				else if (expr.Calls((Symbol) "cos", 1) && (a = expr.Args[0]) != null) return Math.Cos(Eval(a, lookup));
				else if (expr.Calls((Symbol) "tan", 1) && (a = expr.Args[0]) != null) return Math.Tan(Eval(a, lookup));
				else if (expr.Calls((Symbol) "asin", 1) && (a = expr.Args[0]) != null) return Math.Asin(Eval(a, lookup));
				else if (expr.Calls((Symbol) "acos", 1) && (a = expr.Args[0]) != null) return Math.Acos(Eval(a, lookup));
				else if (expr.Calls((Symbol) "atan", 1) && (a = expr.Args[0]) != null) return Math.Atan(Eval(a, lookup));
				else if (expr.Calls((Symbol) "sec", 1) && (a = expr.Args[0]) != null) return 1 / Math.Cos(Eval(a, lookup));
				else if (expr.Calls((Symbol) "csc", 1) && (a = expr.Args[0]) != null) return 1 / Math.Sin(Eval(a, lookup));
				else if (expr.Calls((Symbol) "cot", 1) && (a = expr.Args[0]) != null) return 1 / Math.Tan(Eval(a, lookup));
				else if (expr.Calls((Symbol) "exp", 1) && (a = expr.Args[0]) != null) return Math.Exp(Eval(a, lookup));
				else if (expr.Calls((Symbol) "ln", 1) && (a = expr.Args[0]) != null) return Math.Log(Eval(a, lookup));
				else if (expr.Calls((Symbol) "log", 1) && (a = expr.Args[0]) != null) return Math.Log10(Eval(a, lookup));
				else if (expr.Calls((Symbol) "ceil", 1) && (a = expr.Args[0]) != null) return Math.Ceiling(Eval(a, lookup));
				else if (expr.Calls((Symbol) "floor", 1) && (a = expr.Args[0]) != null) return Math.Floor(Eval(a, lookup));
				else if (expr.Calls((Symbol) "sign", 1) && (a = expr.Args[0]) != null) return Math.Sign(Eval(a, lookup));
				else if (expr.Calls((Symbol) "abs", 1) && (a = expr.Args[0]) != null) return Math.Abs(Eval(a, lookup));
				else if (expr.Calls((Symbol) "rnd", 0)) return (number) _r.NextDouble();
				else if (expr.Calls((Symbol) "rnd", 1) && (a = expr.Args[0]) != null) return (number) _r.Next((int) Eval(a, lookup));
				else if (expr.Calls((Symbol) "rnd", 2) && (a = expr.Args[0]) != null && (b = expr.Args[1]) != null) return (number) _r.Next((int) Eval(a, lookup), (int) Eval(b, lookup));
				else if (expr.Calls((Symbol) "fact", 1) && (a = expr.Args[0]) != null) return Factorial(Eval(a, lookup));
			}
			throw new ArgumentException("Expression not understood: {0}".Localized(expr));
		}
	
		static double Mod(double x, double y)
		{
			double m = x % y;
			return m + (m < 0 ? y : 0);
		}
		static double Factorial(double n) => 
		n <= 1 ? 1 : n * Factorial(n - 1);
		static double P(int n, int k) => 
		k <= 0 ? 1 : k > n ? 0 : n * P(n - 1, k - 1);
		static double C(ulong n, ulong k) {
			if (k > n)
				return 0;
			k = Math.Min(k, n - k);
			double result = 1;
			for (ulong d = 1; d <= k; ++d) {
				result *= n--;
				result /= d;
			}
			return result;
		}
		static Random _r = new Random();
	}
	// Derived class for 2D graphing calculator
	class Calculator2D : CalculatorCore {
		static readonly Symbol sy_x = (Symbol) "x";
		public Calculator2D(LNode Expr, Dictionary<Symbol, LNode> Vars, CalcRange XRange)
			 : base(Expr, Vars, XRange) { }
		public override CalculatorCore WithExpr(LNode newValue) {
			return new Calculator2D(newValue, Vars, XRange);
		}
		public override CalculatorCore WithVars(Dictionary<Symbol, LNode> newValue) {
			return new Calculator2D(Expr, newValue, XRange);
		}
		public override CalculatorCore WithXRange(CalcRange newValue) {
			return new Calculator2D(Expr, Vars, newValue);
		}
		public override object Run()
		{
			var results = new number[XRange.PxCount];
			number x = XRange.Lo;
		
			Func<Symbol, number> lookup = null;
			lookup = name => (name == sy_x ? x : Eval(Vars[name], lookup));
		
			for (int i = 0; i < results.Length; i++) {
				results[i] = Eval(Expr, lookup);
				x += XRange.StepSize;
			}
			return Results = results;
		}
		public override number? GetValueAt(int x, int _) {
			var tmp_14 = (uint) x;
			var r = ((number[]) Results);
			return 
			tmp_14 < (uint) r.Length ? r[x] : (number?) null;
		}
	}

	// Derived class for pseudo-3D and "equation" calculator
	class Calculator3D : CalculatorCore {
		static readonly Symbol sy_x = (Symbol) "x", sy_y = (Symbol) "y";
		public Calculator3D(LNode Expr, Dictionary<Symbol, LNode> Vars, CalcRange XRange, CalcRange YRange)
			 : base(Expr, Vars, XRange) {
			this.YRange = YRange;
		}
		public CalcRange YRange { get; private set; }
		public override CalculatorCore WithExpr(LNode newValue) {
			return new Calculator3D(newValue, Vars, XRange, YRange);
		}
		public override CalculatorCore WithVars(Dictionary<Symbol, LNode> newValue) {
			return new Calculator3D(Expr, newValue, XRange, YRange);
		}
		public override CalculatorCore WithXRange(CalcRange newValue) {
			return new Calculator3D(Expr, Vars, newValue, YRange);
		}
		public Calculator3D WithYRange(CalcRange newValue) {
			return new Calculator3D(Expr, Vars, XRange, newValue);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)] public CalcRange Item4 {
			get {
				return YRange;
			}
		}
		public bool EquationMode { get; private set; }
	
		public override object Run()
		{
			{
				var Expr_13 = Expr;
				LNode L, R;
				if (Expr_13.Calls(CodeSymbols.Assign, 2) && (L = Expr_13.Args[0]) != null && (R = Expr_13.Args[1]) != null || Expr_13.Calls(CodeSymbols.Eq, 2) && (L = Expr_13.Args[0]) != null && (R = Expr_13.Args[1]) != null) {
					EquationMode = true;
					number[,] results = RunCore(LNode.Call(CodeSymbols.Sub, LNode.List(L, R)).SetStyle(NodeStyle.Operator), true);
					number[,] results2 = new number[results.GetLength(0) - 1, results.GetLength(1) - 1];
					for (int i = 0; i < results.GetLength(0) - 1; i++) {
						for (int j = 0; j < results.GetLength(1) - 1; j++) {
							int sign = Math.Sign(results[i, j]);
							if (sign == 0 || sign != Math.Sign(results[i + 1, j]) || 
							sign != Math.Sign(results[i, j + 1]) || 
							sign != Math.Sign(results[i + 1, j + 1]))
								results2[i, j] = (number) 1;
							else
								results2[i, j] = (number) 0;
						}
					}
					return Results = results2;
				} else {
					EquationMode = Expr.ArgCount == 2 && Expr.Name.IsOneOf(
					CodeSymbols.GT, CodeSymbols.LT, CodeSymbols.GE, CodeSymbols.LE, CodeSymbols.Neq, CodeSymbols.And, CodeSymbols.Or);
					return Results = RunCore(Expr, false);
				}
			}
		}
		public number[,] RunCore(LNode expr, bool difMode)
		{
			var results = new number
			[YRange.PxCount + (difMode ? 1 : 0), XRange.PxCount + (difMode ? 1 : 0)];
			number x = XRange.Lo, startx = x;
			number y = YRange.Lo;
			if (difMode) {
				x -= XRange.StepSize / 2;
				y -= YRange.StepSize / 2;
			}
		
			Func<Symbol, number> lookup = null;
			lookup = name => (name == sy_x ? x : name == sy_y ? y : Eval(Vars[name], lookup));
		
			for (int yi = 0; yi < results.GetLength(0); yi++, x = startx) {
				for (int xi = 0; xi < results.GetLength(1); xi++) {
					results[yi, xi] = Eval(expr, lookup);
					x += XRange.StepSize;
				}
				y += YRange.StepSize;
			}
			return results;
		}
		public override number? GetValueAt(int x, int y) {
			var tmp_15 = (uint) x;
			var r = ((number[,]) Results);
			return 
			tmp_15 < (uint) r.GetLength(1) && 
			(uint) y < (uint) r.GetLength(0) ? r[y, x] : (number?) null;
		}
	}

}