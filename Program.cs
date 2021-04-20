using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorization
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> Ans = new List<int>();
                Factorization fact = new Factorization();

                int a, b, c;
                int Elm = 1;

                while(true)
                {
                    Console.WriteLine("2次の項は？");
                    a = int.Parse(Console.ReadLine());
                    Console.WriteLine("1次の項は？");
                    b = int.Parse(Console.ReadLine());
                    Console.WriteLine("定数項は？");
                    c = int.Parse(Console.ReadLine());

                    fact.createFactorization(a, b, c, ref Ans, ref Elm);

                    if (Ans.Count == 0)
                    {
                        if (Elm != 1) Console.WriteLine("共通因数は{0}だけど、", Elm);
                        else Console.WriteLine("共通因数はありません。");
                        Console.WriteLine("二乗公式による因数分解はできませんでした。");
                        string Retryflg = "";
                        Console.WriteLine("まだ続けますか？ はい:y, いいえ:n");
                        Retryflg = Console.ReadLine();
                        if (Retryflg == "y")
                        {
                            continue;
                        }
                        else if(Retryflg == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("yかnだっつってんのにー");
                            Console.WriteLine("じゃあな。");
                            break;
                        }
                    }

                    if(Ans[0] < 0 || Ans[2] < 0)
                    {
                        for(int ic = 0; ic < 4; ic++)
                        {
                            Ans[ic] = Ans[ic] * (-1);
                        }
                    }
                    for(int ic = 0; ic < Ans.Count; ic++)
                    {
                        if (Ans[ic] % Elm == 0) Ans[ic] = Ans[ic] / Elm;
                    }
                    if (Elm != 1)
                    {
                        Console.WriteLine("共通因数：{0}", Elm);
                    }
                    else
                    {
                        Console.WriteLine("共通因数なし");
                    }
                    Console.WriteLine("{0}, {1}, {2}, {3}", Ans[0], Ans[1], Ans[2], Ans[3]);


                    string flg = "";
                    Console.WriteLine("まだ続けますか？ はい:y, いいえ:n");
                    flg = Console.ReadLine();
                    if (flg == "y") continue;
                    else if (flg == "n") break;
                    else
                    {
                        Console.WriteLine("yかnを入力しろよ。");
                        break;
                    }
                }

                Console.WriteLine("ところで、数字を入力すると素因数分解するけど、どうする？ する：y, しない：n");
                string PFflg = Console.ReadLine();
                if(PFflg == "y")
                {
                    Console.WriteLine("数字を入力すると素因数分解するよ。");
                    long num = long.Parse(Console.ReadLine());
                    List<long> fList = new List<long>();
                    List<long> fnumList = new List<long>();
                    Factorization p = new Factorization();
                    p.createPrimeFactorization(num, ref fList, ref fnumList);
                    Console.WriteLine("{0}の素因数分解はというと", num);
                    Console.Write("素因数：");
                    for (int ic = 0; ic < fnumList.Count; ic++)
                    {
                        if (fnumList[ic] == 0) continue;
                        Console.Write("{0:d6}", fList[ic]);
                        if (ic != fnumList.Count - 1) Console.Write(",");
                    }
                    Console.WriteLine();
                    Console.Write("次数：　");
                    for (int ic = 0; ic < fnumList.Count; ic++)
                    {
                        if (fnumList[ic] == 0) continue;
                        Console.Write("{0:d6}", fnumList[ic]);
                        if (ic != fnumList.Count - 1) Console.Write(",");
                    }
                    Console.WriteLine();
                }
                else if(PFflg == "n")
                {

                }
                else
                {
                    Console.WriteLine("yかnかで入力しろよな。");
                    return;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
