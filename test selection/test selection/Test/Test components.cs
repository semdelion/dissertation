using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASCPR
{
    class Header
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public VerificationDescriptors Verifier { get; set; }

        public Header()
        {
            Name = "";
            Description = "";
            Verifier = 0;
        }

        public Header(Header h)
        {
            Name = h.Name;
            Description = h.Description;
            Verifier = h.Verifier;
        }
    }

    class Question
    {
        public string _Question { get; set; }
        public List<string> _Answer { get; set; }

        public Question()
        {
            _Question = "";
            _Answer = new List<string>();
        }

        public Question(Question q)
        {
            _Question = q._Question;
            _Answer = new List<string>(q._Answer);
        }
    }

    class Element
    {
        public int Question { get; private set; }
        public int Answer { get; private set; }
        public double Point { get; private set; }

        public Element()
        {
            Question = Answer = 0;
            Point = 0;
        }

        public Element(Element k)
        {
            Question = k.Question;
            Answer = k.Answer;
            Point = k.Point;
        }
        public Element(int Q, int A, double P)
        {
            Question = Q;
            Answer = A;
            Point = P;
        }
    }

    class Key
    {
        List<Element> _Element;

        public Element this[int index]
        {
            get => _Element[index]; 
            set => _Element[index] = value; 
        }

        public void Add(Element el) => _Element.Add(el);

        public int Count => _Element.Count;

        public void RemoveAt(int index) => _Element.RemoveAt(index);

        public Key() => _Element = new List<Element>();

        public Key(Key k) => _Element = new List<Element>(k._Element);
    } 

    class Scale
    {
        public string If_scale { get;  private set; }
        public string Name_scale { get; private set; }
        public string Manifestation { get; private set; }

        public Scale() => If_scale = Name_scale = Manifestation = "";
        
        public Scale(Scale s)
        {
            If_scale = s.If_scale;
            Name_scale = s.Name_scale;
            Manifestation = s.Manifestation;
        }

        public Scale(string If, string Name, string Manif)
        {
            If_scale = If;
            Name_scale = Name;
            Manifestation = Manif;
        }

    }

    class Line
    {
        public PointF A { get; set; }
        public PointF B { get; set; }

        public Line()
        {
            A = new PointF();
            B = new PointF();
        }
        
        public Line(Line L)
        {
            A = L.A;
            B = L.B;
        }

        public Line(PointF A, PointF B)
        {
            this.A = A;
            this.B = B;
        }

        public Line(float x1, float y1, float x2, float y2)
        {
            A = new PointF(x1, y1);
            B = new PointF(x2, y2);
        }

        public float Equation_of_the_line(float x)
        {
            float Ax, By, C;
            By = B.X - A.X;
            if (By == 0)
                throw new Exception("Error: Vertical line");
            Ax = (x * (A.Y - B.Y)) / -By;
            C = (A.X * B.Y - B.X * A.Y) / -By;
            return Ax + C;
        }
    }

    class Trapeze
    {
        public Line Left_side { get; set; }
        public Line Right_side { get; set; }

        public Trapeze()
        {
            Left_side = new Line();
            Right_side = new Line();
        }

        public Trapeze(Trapeze T)
        {
            Left_side = T.Left_side;
            Right_side = T.Right_side;
        }

        public Trapeze(Line Left_side, Line Right_side)
        {
            this.Left_side = Left_side;
            this.Right_side = Right_side;
        }

        public float Measure_of_belonging(float x)
        {
            if (x < Left_side.A.X || x > Right_side.B.X)
                return 0;
            if (x >= Left_side.B.X && x <= Right_side.A.X)
                return 1;
            if (x >= Left_side.A.X && x <= Left_side.B.X)
                return Left_side.Equation_of_the_line(x);
            if (x >= Right_side.A.X && x <= Right_side.B.X)
                return Right_side.Equation_of_the_line(x);
            throw new ArgumentOutOfRangeException { };
        }
    }

    class Fuzzy_sets ///TODO for all functions
    {
        public string Name { get; set; }
        public virtual List<Trapeze> Functions { get; set; }

        public Fuzzy_sets()
        {
            Name = "";
            Functions = new List<Trapeze>();
        }

        public Fuzzy_sets(Fuzzy_sets F_s)
        {
            Name = F_s.Name;
            Functions = new List<Trapeze>(F_s.Functions);
        }
    }

    class Answers_to_question
    {
        List<int> Answers;
        public int this[int index]
        {
            get => Answers[index]; 
            set => Answers[index] = value; 
        }
        public void Add(int el) => Answers.Add(el);

        public int Count => Answers.Count;

        public Answers_to_question() => Answers = new List<int>();

        public Answers_to_question(List<int> A_q) => Answers = new List<int>(A_q);

        public Answers_to_question(Answers_to_question A_q) => Answers = new List<int>(A_q.Answers);
    }

    class Answers_to_Test
    {
        List<Answers_to_question> Answers_to_the_questions;

        public Answers_to_question this[int index]
        {
            get => Answers_to_the_questions[index]; 
            set => Answers_to_the_questions[index] = value; 
        }

        public void Add(Answers_to_question ans_q) => Answers_to_the_questions.Add(ans_q);

        public int Count => Answers_to_the_questions.Count;

        public Answers_to_Test() => Answers_to_the_questions = new List<Answers_to_question>();

        public Answers_to_Test(Answers_to_Test A_t) => Answers_to_the_questions = new List<Answers_to_question>(A_t.Answers_to_the_questions);
    }
}
