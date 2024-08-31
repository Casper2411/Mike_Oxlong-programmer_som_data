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
        abstract public int eval(Dictionary<string, int> env);
        abstract public AExpr simplify();
    }

    public class CstI : AExpr
    {
        public int I;
        public CstI(int i)
        {
            I = i;
        }

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

    public class Var : AExpr
    {
        public string Name;

        public Var(String name)
        {
            Name = name;
        }

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

    public abstract class Binop : AExpr{}

    public class Add : Binop
    {
        public AExpr AExpr1;
        public AExpr AExpr2;

        public Add(AExpr aExpr1, AExpr aExpr2)
        {
            AExpr1 = aExpr1;
            AExpr2 = aExpr2;
        }

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
            if (AExpr1 is CstI)
            {
                CstI constant = AExpr1 as CstI;
                if (constant.I == 0)
                {
                    return AExpr2;
                }
            }
            else if (AExpr2 is CstI)
            {
                CstI constant = AExpr2 as CstI;
                if (constant.I == 0)
                {
                    return AExpr1;
                }
            }

            return new Add(AExpr1, AExpr2);
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
            if (AExpr2 is CstI)
            {
                CstI constant = AExpr2 as CstI;
                if (constant.I == 0)
                {
                    return AExpr1;
                }
            } else if (AExpr1 is CstI && AExpr2 is CstI)
            {
                CstI constant1 = AExpr1 as CstI;
                CstI constant2 = AExpr2 as CstI;
                if (constant1 == constant2)
                {
                    return new CstI(0);
                }
            }
            return new Sub(AExpr1, AExpr2);
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
            if (AExpr1 is CstI)
            {
                CstI constant = AExpr1 as CstI;
                if (constant.I == 1)
                {
                    return AExpr2;
                } 
                if (constant.I == 0)
                {
                    return new CstI(0);
                }
            } else if (AExpr2 is CstI)
            {
                CstI constant = AExpr2 as CstI;
                if (constant.I == 1)
                {
                    return AExpr1;
                } 
                if (constant.I == 0)
                {
                    return new CstI(0);
                }
            }

            return new Mul(AExpr1, AExpr2);
        }
    }
}

