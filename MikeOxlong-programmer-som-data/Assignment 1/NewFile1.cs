using System;

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
    }

    public class CstI : AExpr
    {
        protected int I;
        public CstI(int i)
        {
            I = i;
        }

        public override string toString()
        {
            return I.ToString();
        }
    }

    public class Var : AExpr
    {
        protected string Name;

        public Var(String name)
        {
            Name = name;
        }

        public override string toString()
        {
            return Name;
        }
    }

    public abstract class Binop : AExpr{}

    public class Add : Binop
    {
        protected AExpr AExpr1;
        protected AExpr AExpr2;

        public Add(AExpr aExpr1, AExpr aExpr2)
        {
            AExpr1 = aExpr1;
            AExpr2 = aExpr2;
        }

        public override string toString()
        {
            return AExpr1.toString() + " + " + AExpr2.toString();
        }
    }
    
    public class Sub : Binop
    {
        protected AExpr AExpr1;
        protected AExpr AExpr2;

        public Sub(AExpr aExpr1, AExpr aExpr2)
        {
            AExpr1 = aExpr1;
            AExpr2 = aExpr2;
        }
        
        public override string toString()
        {
            return AExpr1.toString() + " - " + AExpr2.toString();
        }
    }
    
    public class Mul : Binop
    {
        protected AExpr AExpr1;
        protected AExpr AExpr2;

        public Mul(AExpr aExpr1, AExpr aExpr2)
        {
            AExpr1 = aExpr1;
            AExpr2 = aExpr2;
        }
        
        public override string toString()
        {
            return AExpr1.toString() + " * " + AExpr2.toString();
        }
    }
}

