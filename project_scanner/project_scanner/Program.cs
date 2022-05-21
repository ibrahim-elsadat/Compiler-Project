using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace project_scanner
{
    class Program
    {
        static int error = 0;
        
        public static void func1(string word, int y, Dictionary<string, string> keywords)
        {
            Console.WriteLine("Line : " + y + "   Token Text: " + word + "  Token Type: " + keywords[word]);
        }
        public static void func2(string word, int y)
        {
            Boolean b = false;
            //Console.WriteLine(word);
            for (int p = 0; p < word.Length; p++)
            {
                if (char.IsNumber(word[p]))
                {
                    b = true;
                }
                else
                {
                    b = false;
                    break;
                }
            }
            //Console.WriteLine(b);
            if (b == true)
            {
                Console.WriteLine("Line : " + y + "   Token Text: " + word + "  Token Type: " + "Constant");
            }
            else
            {
                if (!char.IsNumber(word[0]))
                {
                    Console.WriteLine("Line : " + y + "   Token Text: " + word + "  Token Type: " + "Identifier");
                }
                else
                {
                    Console.WriteLine("Line : " + y + "   Error in Token Text: " + word);
                    error++;
                }
            }
        }
        public static Boolean check1(char l)
        {
            if (l != '=' && l != '<' && l != '>' && l != '+' && l != '-' && l != '*' && l != '/' && l != ';' && l != '[' && l != ']' && l != '~')
            {
                return true;
            }
            return false;
        }
        public static Boolean check2(char l1, char l2)
        {
            if ((l1 == '-' && 2 == '>') || (l1 == '&' && l2 == '&') || (l1 == '|' && l2 == '|'))
            {
                return true;
            }
            if ((l1 == '=' && l2 == '=') || (l1== '!' && l2 == '=') || (l1 == '<' && l2 == '=') || (l1 == '>' && l2 == '='))
            {
                return true;
            }
                return false;
        }
        public enum State
        {
            A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
            AA, AB, AC, AD, AE, AF, AG, AH, AI, AJ, AK, AL, AM, AN, AO, AP, AQ,
            AR, AS, AT, AU, AV, AW, AX, AY, AZ, BA, BB, BC, BD, BE, BF, BG, BH,
            BI, BJ, BK, BL, BM, BN, BO, BP, BQ, BR, BS, BT, BU, BV, BW, BX, BY, BZ,
            CA, CB, CC, CD, CE, CF, CG, CH, CI, CJ, CK, CL, CM, CN, CO, CP, CQ, CR
        }

        static void Main(string[] args)
        {
            Dictionary<string, string> keywords = new Dictionary<string, string>()
            {
                {"If", "Condition" }, {"Else", "Condition"}, {"Iow", "Integer"}, {"SIow", "SInteger"}, {"Chlo", "Character"}, {"Chain", "String"},
                { "Iowf", "Float"}, {"SIowf", "SFloat" }, {"Worthless", "Void"}, {"Loopwhen", "Loop"}, {"Iteratewhen", "Loop"}, {"Turnback", "Return"},
                { "Stop", "Break"}, { "Loli", "Struct"}, {"+", "Arithmetic Operation" }, {"-", "Arithmetic Operation"}, {"*", "Arithmetic Operation"},
                { "/", "Arithmetic Operation"}, { "&&", "Logic operators"}, {"||", "Logic operators"}, { "~", "Logic operators"}, {"==", "relational operators" },
                { "<", "relational operators"}, {">", "relational operators"}, { "!=", "relational operators"}, {"<=", "relational operators"},
                { ">=", "relational operators"}, { "=", "Assignment operator"}, { "->", "Access Operator"}, {"{", "Braces"}, { "}", "Braces"},
                { "[", "Braces"}, { "]", "Braces"}, { "'", "Quotation Mark"}, { "\"", "Quotation Mark"}, { "\\d+", "Constant"}, { "Include", "Inclusion"},
                {"(", "Braces"}, { ")", "Braces"}, { ";", "semicolon"}
            };
            String chars = "!\"#&'-/<=>@BCDEILPSTW[\\]abcdefhiklnoprstuw{}~";
            int[,] tranTable = new int[95, 45];
            for (int x = 0; x < 95; x++)
            {
                for (int y = 0; y < 45; y++)
                {
                    tranTable[x, y] = -1;
                }
            }

            tranTable[(int)State.A, 0] = (int)State.B;
            tranTable[(int)State.A, 1] = (int)State.C;
            tranTable[(int)State.A, 2] = (int)State.D;
            tranTable[(int)State.A, 3] = (int)State.E;
            tranTable[(int)State.A, 4] = (int)State.F;
            tranTable[(int)State.A, 5] = (int)State.G;
            tranTable[(int)State.A, 6] = (int)State.H;
            tranTable[(int)State.A, 7] = (int)State.I;
            tranTable[(int)State.A, 8] = (int)State.J;
            tranTable[(int)State.A, 9] = (int)State.K;
            tranTable[(int)State.A, 10] = (int)State.L;
            tranTable[(int)State.A, 11] = (int)State.M;
            tranTable[(int)State.A, 12] = (int)State.N;
            tranTable[(int)State.A, 13] = (int)State.O;
            tranTable[(int)State.A, 14] = (int)State.P;
            tranTable[(int)State.A, 15] = (int)State.Q;
            tranTable[(int)State.A, 16] = (int)State.R;
            tranTable[(int)State.A, 17] = (int)State.S;
            tranTable[(int)State.A, 18] = (int)State.T;
            tranTable[(int)State.A, 19] = (int)State.U;
            tranTable[(int)State.A, 20] = (int)State.V;
            tranTable[(int)State.A, 21] = (int)State.W;
            tranTable[(int)State.A, 22] = (int)State.X;
            tranTable[(int)State.A, 23] = (int)State.Y;
            tranTable[(int)State.A, 42] = (int)State.Z;
            tranTable[(int)State.A, 43] = (int)State.AA;
            tranTable[(int)State.A, 44] = (int)State.AB;

            tranTable[(int)State.B, 8] = (int)State.AC;
            tranTable[(int)State.E, 3] = (int)State.AD;
            tranTable[(int)State.G, 9] = (int)State.AE;
            tranTable[(int)State.I, 8] = (int)State.AF;
            tranTable[(int)State.J, 8] = (int)State.AG;
            tranTable[(int)State.K, 8] = (int)State.AH;
            tranTable[(int)State.N, 30] = (int)State.AI;
            tranTable[(int)State.O, 13] = (int)State.AJ;
            tranTable[(int)State.P, 33] = (int)State.AK;
            tranTable[(int)State.Q, 29] = (int)State.AL;
            tranTable[(int)State.Q, 34] = (int)State.AM;
            tranTable[(int)State.Q, 35] = (int)State.AN;
            tranTable[(int)State.Q, 39] = (int)State.AO;
            tranTable[(int)State.R, 35] = (int)State.AP;
            tranTable[(int)State.T, 15] = (int)State.AQ;
            tranTable[(int)State.T, 39] = (int)State.AR;
            tranTable[(int)State.U, 40] = (int)State.AS;
            tranTable[(int)State.V, 35] = (int)State.AT;
            tranTable[(int)State.X, 22] = (int)State.AU;
            tranTable[(int)State.AI, 24] = (int)State.AV;
            tranTable[(int)State.AI, 33] = (int)State.AW;
            tranTable[(int)State.AJ, 13] = (int)State.AJ;
            tranTable[(int)State.AJ, 38] = (int)State.AX;
            tranTable[(int)State.AM, 26] = (int)State.AY;

            tranTable[(int)State.AN, 41] = (int)State.AZ;
            tranTable[(int)State.AO, 28] = (int)State.BA;
            tranTable[(int)State.AP, 33] = (int)State.BB;
            tranTable[(int)State.AP, 35] = (int)State.BC;
            tranTable[(int)State.AQ, 35] = (int)State.BD;
            tranTable[(int)State.AR, 35] = (int)State.BE;
            tranTable[(int)State.AS, 37] = (int)State.BF;
            tranTable[(int)State.AT, 37] = (int)State.BG;
            tranTable[(int)State.AV, 31] = (int)State.BH;
            tranTable[(int)State.AW, 35] = (int)State.BI;
            tranTable[(int)State.AX, 28] = (int)State.BJ;
            tranTable[(int)State.AY, 33] = (int)State.BK;
            tranTable[(int)State.AZ, 29] = (int)State.BL;
            tranTable[(int)State.BA, 37] = (int)State.BM;
            tranTable[(int)State.BB, 31] = (int)State.BN;
            tranTable[(int)State.BC, 36] = (int)State.BO;
            tranTable[(int)State.BD, 41] = (int)State.BP;
            tranTable[(int)State.BE, 36] = (int)State.BQ;
            tranTable[(int)State.BF, 34] = (int)State.BR;
            tranTable[(int)State.BG, 39] = (int)State.BS;
            tranTable[(int)State.BH, 34] = (int)State.BT;
            tranTable[(int)State.BK, 40] = (int)State.BU;
            tranTable[(int)State.BM, 24] = (int)State.BV;
            tranTable[(int)State.BO, 41] = (int)State.BW;

            tranTable[(int)State.BP, 29] = (int)State.BX;
            tranTable[(int)State.BR, 25] = (int)State.BY;
            tranTable[(int)State.BS, 30] = (int)State.BZ;
            tranTable[(int)State.BU, 27] = (int)State.CA;
            tranTable[(int)State.BV, 39] = (int)State.CB;
            tranTable[(int)State.BW, 30] = (int)State.CC;
            tranTable[(int)State.BY, 24] = (int)State.CD;
            tranTable[(int)State.BZ, 33] = (int)State.CE;
            tranTable[(int)State.CA, 28] = (int)State.CF;
            tranTable[(int)State.CB, 28] = (int)State.CG;
            tranTable[(int)State.CC, 28] = (int)State.CH;
            tranTable[(int)State.CD, 26] = (int)State.CI;
            tranTable[(int)State.CE, 28] = (int)State.CJ;
            tranTable[(int)State.CG, 41] = (int)State.CK;
            tranTable[(int)State.CH, 34] = (int)State.CL;
            tranTable[(int)State.CI, 32] = (int)State.CM;
            tranTable[(int)State.CJ, 38] = (int)State.CN;
            tranTable[(int)State.CK, 30] = (int)State.CO;
            tranTable[(int)State.CN, 38] = (int)State.CP;
            tranTable[(int)State.CO, 28] = (int)State.CQ;
            tranTable[(int)State.CQ, 34] = (int)State.CR;

            Boolean b = false;
            int state = 0;
            string word = "";
            string line;
            StreamReader file = null;

            try
            {
                file = new StreamReader(@"A:\A\project_scanner\Compiler-Project\project_scanner\project_scanner\code.txt");
                for (int y = 1; (line = file.ReadLine()) != null; y++)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] != ' ')
                        {
                            if (!char.IsPunctuation(line[i]) && check1(line[i]))
                            {
                                //0
                                if (state != -1 && chars.IndexOf(line[i]) != -1)
                                {
                                    if (tranTable[state, chars.IndexOf(line[i])] == -1)
                                    {
                                        word += line[i];
                                        continue;
                                    }
                                    else
                                    {
                                        state = tranTable[state, chars.IndexOf(line[i])];
                                        word += line[i];
                                    }
                                }
                                else
                                {
                                    word += line[i];
                                    continue;
                                }
                            }

                            else
                            {
                                if(line[i] == '_')
                                {
                                    word += line[i];
                                    continue;
                                }
                                if (word != "")
                                {
                                    if (keywords.ContainsKey(word))
                                    {
                                        func1(word, y, keywords);
                                    }
                                    else
                                    {
                                        func2(word, y);
                                        state = 0;
                                    }
                                    word = "";
                                    if (i != line.Length - 1)
                                    {
                                        if (check2(line[i], line[i + 1]))
                                        {
                                            word += line[i];
                                            word += line[i + 1];
                                            i += 1;
                                            if (keywords.ContainsKey(word))
                                            {
                                                func1(word, y, keywords);

                                            }
                                            else
                                            {
                                                func2(word, y);
                                                state = 0;
                                            }
                                            word = "";
                                            continue;
                                        }
                                        
                                    }
                                    
                                    word = "" + line[i];
                                    if (keywords.ContainsKey(word))
                                    {
                                        func1(word, y, keywords);

                                    }
                                    else
                                    {
                                        func2(word, y);
                                        state = 0;
                                    }
                                    if (line[i] == ';')
                                    {
                                        y+=1;
                                    }
                                    word = "";
                                }
                                else
                                {
                                    if (i != line.Length - 1)
                                    {
                                        if (check2(line[i], line[i+1]))
                                        {
                                            word += line[i];
                                            word += line[i + 1];
                                            i += 1;
                                            if (keywords.ContainsKey(word))
                                            {
                                                func1(word, y, keywords);

                                            }
                                            else
                                            {
                                                func2(word, y);
                                                state = 0;
                                            }
                                            word = "";
                                            continue;
                                        }
                                    }
                                    word += line[i];
                                    if (keywords.ContainsKey(word))
                                    {
                                        func1(word, y, keywords);

                                    }
                                    else
                                    {
                                        func2(word, y);
                                        state = 0;
                                    }
                                    word = "";
                                }
                            }
                        }
                        else
                        {
                            if (word != "")
                            {
                                if (keywords.ContainsKey(word))
                                {
                                    func1(word, y, keywords);

                                }
                                else
                                {
                                    func2(word, y);
                                    state = 0;
                                }
                            }
                            word = "";
                        }
                    }
                    if (word != "")
                    {
                        if (keywords.ContainsKey(word))
                        {
                            func1(word, y, keywords);

                        }
                        else
                        {
                            func2(word, y);
                            state = 0;
                        }
                    }
                }
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
            Console.WriteLine("\nTotal NO of errors: "+error+"\n");
            Console.ReadLine();
        }

    }
}
