using System; 
namespace Emp1
{

public class Employee {
    protected string Name ;
    protected string Address;
    protected int IdNum;

    public Employee(string name, string address, int id){
        this.Name    = name;
        this.Address = address;
        this.IdNum   = id; 
    }

    
    public virtual void displEmpInfo(){
        //Console.WriteLine("Empl. Name = {0} \n Empl Address = {1} \n Empl Id # ={2}", Name, Address,  IdNum);
        Console.WriteLine("{0,-20} {11,-30} {2,-8}", Name, Address,  IdNum);
    }

    // if we made class abstract, we can make this function abstract,
    // so we do not have to implement it
    public virtual double calcPay(){
          return 0;      // does not make any sense having a function that return 0;
      }

    public virtual void printPaySlip(){

    }
}

//------------------------------------------------------------------------------------

public class TempEmployee:Employee{
    float hoursWorked;
    float hourlyWage;

    public TempEmployee(string eName, string Address, int id, float hwrkd, float wage ):base(eName, Address, id){
        setWHours(hwrkd);
        setWage(wage);
    }
    public void setWHours(float hrs){
        hoursWorked = hrs ;
    }
    public float getWHours(){
        return hoursWorked;
    }
    public void setWage(float w){
        hourlyWage = w ;
    }
    public float getWage(){
        return hourlyWage;
    }

public override double calcPay(){
    return hourlyWage * hoursWorked;
}

public override void printPaySlip(){
    //Console.WriteLine("Name: {0} \t Worked Hours: {1} \t Hourly Wage: {2} \n Sallary: {3}",Name,hoursWorked,hourlyWage,calcPay());
    Console.WriteLine("{0,-20} {1,-10:F2} {2,-10:F2} {3,-10:F2}",Name,hoursWorked,hourlyWage,calcPay());
}
public override void displEmpInfo(){
    base.displEmpInfo();
    //Console.WriteLine("Empl. Name = {0} \n Empl Address = {1} \n Empl Id # ={2}", Name, Address,  IdNum);
    Console.WriteLine("{0,5:F2} {1,5:F2}",hoursWorked,hourlyWage);  
    //Console.WriteLine("Worked Hours: {0} \n Wage/Hr: {1}",hoursWorked,hourlyWage);  
}

}


public class SalariedEmployee : Employee
{
    private float salary;

    public float getSalary()
    {
        return salary;
    }

    public void setSalary(float value)
    {
        salary = value;
    }

    private float bonus;

    public float getBonus()
    {
        return bonus;
    }

    public void setBonus(float value)
    {
        bonus = value;
    }

    public SalariedEmployee(string eName, string Address, int id, float sal, float extra) : base(eName, Address, id)
    {
        setSalary(sal);
        setBonus(extra);
    }

    public override double calcPay()
    {
        return getSalary() - (getSalary() * 0.02) + getBonus();
    }

    public override void printPaySlip()
    {
        Console.WriteLine("Name: {0} \t Base Salary: {1} \t Bonuses: {2} \n Sallary: {3}", Name, getSalary(), getBonus(), calcPay());
    }
    public override void displEmpInfo()
    {
        base.displEmpInfo();
        //Console.WriteLine("Empl. Name = {0} \n Empl Address = {1} \n Empl Id # ={2}", Name, Address,  IdNum);
        Console.WriteLine("Base Salary: {0} \n Bonus/Hr: {1}", getSalary(), getBonus());
    }


}

}