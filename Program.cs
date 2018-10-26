using System;
using System.Collections.Generic;
using System.IO;

namespace Emp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // declaring a List of type TempEmployee to store the objects
            List<TempEmployee> tmpList = new List<TempEmployee>();
            //we can do the same for the other class (SalariedEmployee) 
            // List<SalariedEmployee> salList = new List<SalariedEmployee>();

            // add new employee object directly to the list using some values
            tmpList.Add(new TempEmployee("John"," 1200 S Western St, Canyon",22, 40f, 15.5f));

            //create employee object using some values, then add the created object to the list
            var e = new TempEmployee("Nick"," 333 Bill st, Amarillo",26, 50f, 15.5f);
            tmpList.Add(e);

            // read some employees info from the cosole "keyboard input", then add them to the list
            string tname;
            string tadd;
            int id;
            float hwrkd ;
            float hwg;
            for(int i=0;i<3;i++){
                Console.WriteLine("Enter Employee #{0} Info:",i+1);
                Console.WriteLine("Name:");
                tname = Console.ReadLine();
                Console.WriteLine("Address:");
                tadd = Console.ReadLine();
                Console.WriteLine("Id #:");
                id  = int.Parse(Console.ReadLine());
                Console.WriteLine("# of Hours Worked:");
                hwrkd  = float.Parse(Console.ReadLine());
                Console.WriteLine(" Wage:");
                hwg  = float.Parse(Console.ReadLine());
                TempEmployee e2 = new TempEmployee(tname, tadd,id,hwrkd,hwg);
                tmpList.Add(e2);
            }


            // To read employees data from file, where each line has one employee info separated by comma ","
            // the employee information is in the file tempEmployee.txt which is in the main directory of this project 
            string inputFileName = "./tempEmployees.txt";
            string[] AllTemEmpData = null;
            if(File.Exists(inputFileName))
                AllTemEmpData = File.ReadAllLines(inputFileName);

            //To extract the info from each line and create employee object then add it to the list
            foreach(string empData in AllTemEmpData){
                string[] eData  = empData.Split(',');
                e = new TempEmployee(eData[0].Trim(),eData[1].Trim(),int.Parse(eData[2]), float.Parse(eData[3]), float.Parse(eData[4]));
                tmpList.Add(e);
            } 

            //To print the information as a Table with header
            //first: print the header 
            Console.WriteLine("\n\n{0,-20} {1,-10} {2,-10} {3,-10}","Name","hWorked","Wage/h","Net Pay");
            //2ND: print line after the header
            Console.WriteLine("{0,-20} {1,-10} {2,-10} {3,-10}","--------------------","----------","----------","----------");

            // to send printPaySlip() message to each employee in the list
            foreach(TempEmployee emp in tmpList ){
                //emp.displEmpInfo();
                emp.printPaySlip();
            }

        }
    }
}
