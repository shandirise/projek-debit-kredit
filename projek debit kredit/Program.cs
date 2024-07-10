using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace projek_debit_kredit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            debetKredit db = new debetKredit();
            string perulangan;


            do
            {
                db.aplikasi();
                Console.WriteLine();
                Console.Write("mulai ulang program? y/n: ");
                perulangan = Console.ReadLine();
                if (perulangan == "y" || perulangan == "Y")
                {
                    Console.Clear();
                }
                else if(perulangan == "n" || perulangan == "N")
                {
                    Console.WriteLine();
                    Console.WriteLine("Terima kasih");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("input anda salah");
                }
            }
            while (perulangan == "y" || perulangan == "Y");
            
            Console.ReadKey();
        }
    }
    class debetKredit
    {
        public void aplikasi()
        {
            int i, j, k, l, m, size, balance, totalKredit, totalDebit;

            size = 99999;
            string[] tanggal = new string[size];
            string[] keterangan = new string[size];
            int[] debit = new int[size];
            int[] kredit = new int[size];

            l = 1;
            k = -1;
            totalDebit = 0;
            totalKredit = 0;
           

            string continous, inputing, tambahData, validasiTanggal;
            tambahData = " ";
            do
            {
                m = 1;
                k++;
                Console.Clear();
                j = 0;
                balance = 0;

                for (i = 0; i == j; i++)
                {
                    switch (l)
                    {
                        case 0:
                            tanggal[k] = "";
                            break;
                        case 1:
                            Console.Clear();
                            Console.Write("input tanggal: ");
                            tanggal[k] =Console.ReadLine();
                            Console.WriteLine();
                            break;
                    }
                    Console.Write("Keterangan data: ");
                    keterangan[k] = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("input d jika ingin memasukan debit, k untuk kredit, dk untuk keduanya: ");
                    inputing = Console.ReadLine();

                    try
                    {
                        if(inputing == "d"|| inputing =="D")
                        {
                            kredit[k] = 0;
                            Console.WriteLine();
                            Console.Write("input debit: ");
                            debit[k] = int.Parse(Console.ReadLine());
                        }
                        else if(inputing == "k" || inputing == "K")
                        {
                            debit[k] = 0;
                            Console.WriteLine();
                            Console.Write("input kredit: ");
                            kredit[k] = int.Parse(Console.ReadLine());
                        }
                        else if(inputing == "dk" || inputing == "Dk" || inputing == "DK" || inputing == "dK")
                        {
                            Console.WriteLine();
                            Console.Write("input debit: ");
                            debit[k] = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("input kredit: ");
                            kredit[k] = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("input data anda salah");
                            kredit[k] = 0;
                            debit[k] = 0;
                        }                      
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("errornya: " + ex.Message);
                    }
                    Console.WriteLine();
                    Console.Write("apakah ingin melanjutkan? y/n: ");
                    continous = Console.ReadLine();
                    switch (continous)
                    {
                        case "Y":
                        case "y":
                            j++;
                            k++;
                            Console.WriteLine();
                            break;
                        case "N":
                        case "n":
                            m = 0;
                            Console.Clear();
                            for (i = 0; i <= k; i++)
                            {
                                balance = balance + debit[i] - kredit[i];
                                switch (tanggal[i]) 
                                {
                                    case "":
                                        break;
                                    default:
                                        Console.WriteLine("\n\ntanggal: " + tanggal[i]);
                                        break;
                                }
                                Console.WriteLine("keterangan: " + keterangan[i]);
                                Console.WriteLine("debit = " + debit[i]);
                                Console.WriteLine("kredit = " + kredit[i]);
                                Console.WriteLine("balance = " + balance);
                                totalDebit = totalDebit + debit[i];
                                totalKredit = totalKredit + kredit[i];
                                Console.WriteLine();
                            }
                            Console.WriteLine("total debit = " + totalDebit + " | total kredit = " + totalKredit + " | balance akhir = " + balance);
                            Console.WriteLine();
                            Console.Write("ingin menambahkan data? y/n: ");
                            tambahData = Console.ReadLine();
                            Console.WriteLine();
                            break;
                        default:
                            Console.WriteLine("input salah");
                            break;
                        
                    }
                    if(tambahData == "y" || tambahData == "Y")
                    {
                        m = 1;
                    }
                    switch (m)
                    {
                        case 0:
                            break;
                        case 1:
                            Console.Write("Ganti tanggal? y/n: ");
                            validasiTanggal = Console.ReadLine();
                            if (validasiTanggal == "y" || validasiTanggal == "Y")
                            {
                                l = 1;
                            }
                            else if (validasiTanggal == "n" || validasiTanggal == "N")
                            {
                                l = 0;
                            }
                            Console.WriteLine();
                            break;
                    }
                }
            }
            while (tambahData == "y" || tambahData == "Y");
        }
    }
}
