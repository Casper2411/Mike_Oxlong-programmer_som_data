using System;
using System.Collections;
using System.Collections.Generic;

namespace ObjectOrientedExpressions
{
    public class Tests
    {
        public static void tests()
        {
            AExpr e1 = new Add(new CstI(17), new Var("z"));
            Console.WriteLine(e1.toString());
            
            AExpr e2 = new Sub(new CstI(6), new Add(new Var("z"), new CstI(15)));
            Console.WriteLine(e2.toString());
            
            AExpr e3 = new Mul(new CstI(3), new Mul(new CstI(5), new CstI(18)));
            Console.WriteLine(e3.toString());
            
            AExpr e4 = new Add(new Var("x"), new Sub(new CstI(8), new CstI(10)));
            Console.WriteLine(e4.toString());
        }
    }
    public abstract class AExpr
    {
        public abstract string toString();
        public abstract int eval(Dictionary<string, int> env);
        public abstract AExpr simplify();
    }

    public class CstI : AExpr
    {
        public int I;
        public CstI(int i)
        {
            I = i;
        }
        
        public void Deconstruct(out int i) => i = I;

        public override string toString()
        {
            return I.ToString();
        }
        
        public override int eval(Dictionary<string, int> env)
        {
            return I;
        }

        public override AExpr simplify()
        {
            return new CstI(I);
        }
    }

    public class Var(string name) : AExpr
    {
        public string Name = name;

        public override string toString()
        {
            return Name;
        }

        public override int eval(Dictionary<string, int> env)
        {
            return env[Name];
        }

        public override AExpr simplify()
        {
            return new Var(Name);
        }
    }

    public abstract class Binop : AExpr;

    public class Add(AExpr aExpr1, AExpr aExpr2) : Binop
    {
        public AExpr AExpr1 = aExpr1;
        public AExpr AExpr2 = aExpr2;

        public override string toString()
        {
            return "(" + AExpr1.toString() + " + " + AExpr2.toString() + ")";
        }

        public override int eval(Dictionary<string, int> env)
        {
            return AExpr1.eval(env) + AExpr2.eval(env);
        }

        public override AExpr simplify()
        {
            return (AExpr1, AExpr2) switch
            {
                (CstI(0), _) => AExpr2,
                (_, CstI(0)) => AExpr1,
                _ => this,
            };
        }
    }

    public class Sub : Binop
    {
        public AExpr AExpr1;
        public AExpr AExpr2;

        public Sub(AExpr aExpr1, AExpr aExpr2)
        {
            AExpr1 = aExpr1;
            AExpr2 = aExpr2;
        }
        
        public override string toString()
        {
            return "(" + AExpr1.toString() + " - " + AExpr2.toString() + ")";
        }
        public override int eval(Dictionary<string, int> env)
        {
            return AExpr1.eval(env) - AExpr2.eval(env);
        }

        public override AExpr simplify()
        {
            return (AExpr1, AExpr2) switch
            {
                (_, CstI(0)) => AExpr1,
                (CstI(var i1), AExpr2: CstI(var i2)) => i1 == i2 ? new CstI(0) : this,
                _ => this,
            };
        }
    }
    
    public class Mul : Binop
    {
        public AExpr AExpr1;
        public AExpr AExpr2;

        public Mul(AExpr aExpr1, AExpr aExpr2)
        {
            AExpr1 = aExpr1;
            AExpr2 = aExpr2;
        }
        
        public override string toString()
        {
            return "(" + AExpr1.toString() + " * " + AExpr2.toString() + ")";
        }
        public override int eval(Dictionary<string, int> env)
        {
            return AExpr1.eval(env) * AExpr2.eval(env);
        }

        public override AExpr simplify()
        {
            return (AExpr1, AExpr2) switch
            {
                (CstI(0) a,_) => a,
                (CstI(1),_) => AExpr2,
                (_, CstI(0) b) => b,
                (_,CstI(1)) => AExpr1,
                _ => this
            };
        }
    }
}

