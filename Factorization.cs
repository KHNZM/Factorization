using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorization
{
    class Factorization : Prime
    {
        protected void createMeasure(int num, ref List<int> measure)
        {
            measure = new List<int>();

            //numが正の場合
            if(num >= 0)
            {
                for (int ic = (-1)*num; ic <= num; ic++)
                {
                    if (ic == 0) continue;
                    if (num % ic == 0)
                    {
                        measure.Add(ic);
                    }
                }
            }
            //numが負の場合
            else
            {
                num = num * (-1);
                for(int ic = -num; ic <= num; ic++)
                {
                    if (ic == 0) continue;
                    if (num % ic == 0)
                    {
                        measure.Add(ic);
                    }
                }
                num = num * (-1);
            }
        }
        protected void Factorout(int[] num, ref int CommElmt)
        {
            int max = 1;
            for(int ic = 0; ic < num.Length; ic++)
            {
                if (ic + 1 == num.Length) break;
                if (num[ic] >= num[ic + 1]) max = num[ic];
            }
            for(int jc = max; jc >= 1; jc--)
            {
                if(num[0]%jc==0 && num[1]%jc==0 && num[2]%jc==0)
                {
                    CommElmt = jc;
                    break;
                }
            }
        }

        public void createFactorization(int a, int b, int c, ref List<int> constant, ref int comelm)    //ax^2 + bx + c
        {
            constant = new List<int>();
            List<int> measure1 = new List<int>();
            List<int> measure2 = new List<int>();
            int[] Coeff = new int[3] { a, b, c };

            Factorout(Coeff, ref comelm);

            createMeasure(a, ref measure1);
            createMeasure(c, ref measure2);

            //定数項が0の場合
            if(measure2.Count == 0)
            {
                measure2.Add(b);
                measure2.Add(0);
            }

            for(int i1 = 0; i1 < measure1.Count; i1++)
            {
                for(int i2 = 0; i2 < measure2.Count; i2++)
                {
                    for(int i3 = 0; i3 < measure1.Count; i3++)
                    {
                        for(int i4 = 0; i4 < measure2.Count; i4++)
                        {
                            if(measure1[i1]*measure2[i2] + measure1[i3]*measure2[i4] == b
                               && measure1[i3]*measure1[i1] == a
                               && measure2[i2]*measure2[i4] == c)
                            {
                                constant.Add(measure1[i3]);
                                constant.Add(measure2[i2]);
                                constant.Add(measure1[i1]);
                                constant.Add(measure2[i4]);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void createPrimeFactorization(long num, ref List<long> PrimeFact, ref List<long> PriFacnumList)
        {
            long PriFacnum = 0;
            int ic = 0;
            long buf = 1;
            Prime prime = new Prime();
            List<long> PrimeList = new List<long>();

            ic = 2;
            buf = num;
            while(ic <= buf)
            {
                if (ic % 2 == 0 && ic != 2) ic += 1;
                if (IsPrime(ic))
                {
                    if (buf % ic == 0)
                    {
                        buf = buf / ic;
                        PriFacnum += 1;

                        if (buf % ic != 0)
                        {
                            PrimeFact.Add(ic);
                            PriFacnumList.Add(PriFacnum);
                            PriFacnum = 0;
                            ic += 1;
                            continue;
                        }
                    }
                    else
                    {
                        ic += 2;
                    }
                    
                    if (buf == 1) break;
                    if (IsPrime(buf) && buf != ic)
                    {
                        PrimeFact.Add(buf);
                        PriFacnumList.Add(1);
                        break;
                    }
                }
                else
                {
                    ic += 2;
                }
            }
            //for(ic = 2; ic <= num; ic += 2)
            //{
            //    if(prime.IsPrime(ic))
            //    {
            //        if (buf % ic != 0) continue;
            //        if (buf % ic == 0)
            //        {
            //            buf = buf / ic;
            //            PriFacnum += 1;
            //        }
            //        if (buf % ic != 0)
            //        {
            //            PrimeFact.Add(ic);
            //            PriFacnumList.Add(PriFacnum);
            //            PriFacnum = 0;
            //        }
            //        if (buf == 1) break;
            //        if (IsPrime(buf) && buf != ic)
            //        {
            //            PrimeFact.Add(buf);
            //            PriFacnumList.Add(1);
            //            break;
            //        }
            //    }
            //    if (ic == 2) ic += 1;
            //}

            //ic = 0;
            //buf = num;
            //while(ic < PrimeList.Count)
            //{
            //    if (buf % PrimeList[ic] == 0)
            //    {
            //        buf = buf / PrimeList[ic];
            //        PriFacnum += 1;
            //    }
            //    if (buf % PrimeList[ic] != 0)
            //    {
            //        PrimeFact.Add(PrimeList[ic]);
            //        PriFacnumList.Add(PriFacnum);
            //        PriFacnum = 0;
            //        ic += 1;
            //    }
            //    if (buf == 1) break;
            //    if (IsPrime(buf) && buf != PrimeList[ic])
            //    {
            //        PrimeFact.Add(buf);
            //        PriFacnumList.Add(1);
            //        break;
            //    }
            //}
        }
    }
}
