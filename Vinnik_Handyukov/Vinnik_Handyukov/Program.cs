using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace Vinnik_Handyukov
{
    class Program
    {
        struct data
        {
            public double a;
            public double b;
            public double alpha;
        }
        static int count = 0;
        
        static bool check(string[] raw)
        {
            bool result = false;
            try
            {
                double a1 = Convert.ToDouble(raw[0]);
                double b1 = Convert.ToDouble(raw[1]);
                double alpha1 = Convert.ToDouble(raw[2]);
                if (a1 > 0 && b1 > 0 && alpha1 > 0 && alpha1 < 180) result = true;
                else Console.WriteLine("Ошибка данных в {0} строке.", count);
            }
            catch
            {
                Console.WriteLine("Ошибка данных в {0} строке.", count);
            }
            return result;
        }

        static void Main(string[] args)
        {
            string in_file = args[0];
            string out_file = args[1];
            if (File.Exists(in_file))
            {
                StreamReader sr = new StreamReader(in_file, Encoding.Default);
                while (!sr.EndOfStream)
                {
                    data[] data_arr = new data[50];
                    for (int i = 0; i < 50; i++)
                    {
                        string[] buf = new string[3];
                        string line="";
                        if (File.Exists(in_file) && ((line = sr.ReadLine()) != null))
                        {
                            line = line.Replace(".", ",");
                            buf = line.Split(';');
                            count++;
                            data raw_data = new data();
                            if (check(buf))
                            {
                                raw_data.a = Convert.ToDouble(buf[0]);
                                raw_data.b = Convert.ToDouble(buf[1]);
                                raw_data.alpha = Convert.ToDouble(buf[2]);
                                data_arr[i] = raw_data;
                            }
                           
                            
                        }
                        else
                        {
                            Console.WriteLine("Файл кончился. Считано {0} записей", count);
                            break;
                        }

                    }
                }
            }
        }
    }
}
