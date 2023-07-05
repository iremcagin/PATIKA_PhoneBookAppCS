using System;
using System.Collections;

namespace dictionary
{
    class Person{
        private string name="";
        private string surname="";
        private string number="";

        public Person(string name, string surname, string number){
            this.name = name;
            this.surname = surname;
            this.number = number;
        }

        public void setName(string name){ this.name = name; }
        public void setSurname(string surname){ this.surname = surname; }
        public void setNumber(string number){ this.number = number; }

        public string getName(){ return name; }
        public string getSurname(){ return surname; }
        public string getNumber(){ return number; }
    }

    class Directory{
        private List<Person> list = new List<Person>();

        // Adds to book at ascending order according to names
        public void Add(string name, string surname, string number){
            bool added = false;

            if(list.Count == 0){ 
                list.Add(new Person(name,surname,number));
                added = true;
            }
            else{
                for(int i=0; i<list.Count; ++i){
                    if(String.Compare(name, list[i].getName())<0){
                        list.Insert(i, new Person(name,surname,number));
                        added = true;
                        break;
                    }
                }
                if(added == false) list.Add(new Person(name,surname,number));
            }
        }

        // prints the contact list in order
        public void order(){
            for(int i=0; i<list.Count; ++i){
                Console.WriteLine(String.Format("Name: {0,-15} Surname: {1,-15} Number: {2,-15}",list[i].getName(),list[i].getSurname(),list[i].getNumber()));
            }
        }
        
        // prints the contact list in reverse order 
        public void revOrder(){
            for(int i=list.Count-1; i>=0; --i){
                Console.WriteLine(String.Format("Name: {0,-15} Surname: {1,-15} Number: {2,-15}",list[i].getName(),list[i].getSurname(),list[i].getNumber()));
            }
        }

        public void updateNum(int i, string newNum){
            list[i].setNumber(newNum);
        }

        public int getCount(){ return list.Count; }
        public string getName(int i){ return list[i].getName(); }
        public string getSurname(int i){ return list[i].getSurname(); }
        public string getNumber(int i){ return list[i].getNumber(); }
        public void remove(int i){ list.RemoveAt(i); }
    }

    class Menu{
        public int menu(){
            Console.WriteLine("");
            Console.WriteLine("Please Choose the Operation from the menu");
            Console.WriteLine("*****************************************");
            Console.WriteLine("(1) Add new contact");
            Console.WriteLine("(2) Delete existing contact");
            Console.WriteLine("(3) Update existing contact");
            Console.WriteLine("(4) List the contacts");
            Console.WriteLine("(5) Search from the dictionary");
            Console.WriteLine("(6) Exit");
            Console.WriteLine("");
            Console.Write("Your Choice: ");
            int op = int.Parse(Console.ReadLine());
            return op;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Menu m = new Menu();
            Directory dict = new Directory();
            dict.Add("Rachel","Green","505 989 86 79");
            dict.Add("Monica","Geller","212 456 35 55");
            dict.Add("Phoebe","Buffay","317 899 70 73");
            dict.Add("Joey","Tribbiani","505 386 11 06");
            dict.Add("Chandler","Bing","442 499 13 72");
            dict.Add("Ross","Geller","209 744 32 84");

            bool ex = false;

            do{
                switch(m.menu()){
                    case 1:
                        string name="";
                        string surname="";
                        string number="";

                        Console.WriteLine("");
                        Console.Write("Please enter a name: ");
                        name = Console.ReadLine();
                        Console.Write("Please enter a surname: ");
                        surname = Console.ReadLine();
                        Console.Write("Please enter a number: ");
                        number = Console.ReadLine();

                        dict.Add(name,surname,number);
                        break;

                    case 2:
                        string input="";
                        bool cont = false;
                        bool found = false;

                        Console.WriteLine("");
                        Console.Write("Please enter name or surname to delete the contact: ");
                        input = Console.ReadLine();

                        do{
                            for(int i=0; i<dict.getCount(); ++i){
                                if(dict.getName(i)==input || dict.getSurname(i)==input){
                                    found = true;

                                    Console.Write("Do you want to delete the '"+dict.getName(i)+" "+dict.getSurname(i)+"' (y/n): ");
                                    char ch = char.Parse(Console.ReadLine());

                                    if(ch == 'y') dict.remove(i);
                                    break;
                                }
                            }

                            if(found==false){
                                Console.WriteLine("");
                                Console.WriteLine("Contact could not be found in the directory. Please make a selection.");
                                Console.WriteLine("(1) Finish the deletion.");
                                Console.WriteLine("(2) Try again.");
                                Console.Write("Your Choice: ");
                                int opp = int.Parse(Console.ReadLine());

                                if(opp==1) cont = false;
                                else if(opp==2) cont = true;
                            }
                        }while(cont);

                        break;

                    // Update
                    case 3:
                        string inputt="";
                        bool contt = false;
                        bool foundd = false;

                        Console.WriteLine("");
                        Console.Write("Please enter name or surname to delete the contact: ");
                        inputt = Console.ReadLine();

                        do{
                            for(int i=0; i<dict.getCount(); ++i){
                                if(dict.getName(i)==inputt || dict.getSurname(i)==inputt){
                                    foundd = true;

                                    Console.Write("Enter new phone number: ");
                                    string newNum = "";
                                    newNum = Console.ReadLine();
                                    dict.updateNum(i, newNum);
                                    break;
                                }
                            }

                            if(foundd==false){
                                Console.WriteLine("");
                                Console.WriteLine("Contact could not be found in the directory. Please make a selection.");
                                Console.WriteLine("(1) Finish the update.");
                                Console.WriteLine("(2) Try again.");
                                Console.Write("Your Choice: ");
                                int opp = int.Parse(Console.ReadLine());

                                if(opp==1) contt = false;
                                else if(opp==2) contt = true;
                            }
                        }while(contt);

                        break;


                    case 4:
                        Console.Write("(1) A-Z, (2) Z-A: ");
                        int op2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("");
                        Console.WriteLine("Phone Book");
                        Console.WriteLine("----------------------------------------------------------");
                        if(op2==1) dict.order();
                        else if(op2==2) dict.revOrder();

                        break;

                    case 5:
                        Console.WriteLine("");
                        Console.WriteLine("Enter the type to make search");
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("(1) According to name or surname");
                        Console.WriteLine("(2) According to phone number");
                        Console.Write("Your Choice: ");
                        int cho = int.Parse(Console.ReadLine());

                        if(cho == 1){
                            string search="";
                            Console.Write("Enter name or surname: ");
                            search = Console.ReadLine();

                            Console.WriteLine("");
                            Console.WriteLine("Result");
                            Console.WriteLine("----------------------------------------------------------------------");
                            for(int i=0; i<dict.getCount();++i){
                                if(dict.getName(i) == search || dict.getSurname(i) == search){
                                   Console.WriteLine(String.Format("Name: {0,-15} Surname: {1,-15} Number: {2,-15}",dict.getName(i),dict.getSurname(i),dict.getNumber(i)));
                                }
                            }
                        }
                        else if(cho ==2){
                            string search="";
                            Console.Write("Enter phone number: ");
                            search = Console.ReadLine();

                            Console.WriteLine("");
                            Console.WriteLine("Result");
                            Console.WriteLine("------------------------------------------------------------------");
                            for(int i=0; i<dict.getCount();++i){
                                if(dict.getNumber(i) == search){
                                   Console.WriteLine(String.Format("Name: {0,-15} Surname: {1,-15} Number: {2,-15}",dict.getName(i),dict.getSurname(i),dict.getNumber(i)));
                                }
                            }
                        }
                        break;
                    case 6:
                        ex = true;
                        break;

                }
            }while(ex == false);
        }
    }
}
