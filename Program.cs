using System;

 class cardHolder
{
    String cardNum;
    int pin;
    String FirstName;
    String LastName;
    double Balance;

    public  cardHolder(string cardNum,int pin,string FirstName,string LastName,double Balance)
    {
        this.cardNum=cardNum;
        this.pin=pin;
        this.FirstName=FirstName;
        this.LastName=LastName;
        this.Balance=Balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstname()
    {
        return FirstName;
    }

    public String getLastName()
    {
        return LastName;
    }

    public double getBalance()
    {
        return Balance;
    }

    public void setNum(String newcardNum)
    {
         cardNum=newcardNum;
    }

    public void setNum(int newPin)
    {
        pin=newPin;
    }

    public void setFisrtName(String newFirstName)
    {
        FirstName=newFirstName;
    }

    public void setLastName(String newLastName)
    {
        LastName=newLastName;
    }

    public void setBalance(double newBalance)
    {
        Balance=newBalance; 
    }

    public static void Main(String[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine("Please Choose One Of The Following Options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money You want to Deposit ?.");
            double deposit =  Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thanku For Depositing Your Money... Your Current Balance is:" + currentUser.getBalance());  
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money You want to Withdraw ?.");
            double withdrawal = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() > withdrawal)
            {
                Console.WriteLine("Insufficient Balance :(");
            }
            else
            {
                double newBalance = currentUser.getBalance() - withdrawal;
                Console.WriteLine("You' re Good to Go! ThankYou :)  ");
            }
        }

        void Balance(cardHolder currentUser)
        {
            Console.WriteLine("Currrent Balance :" + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532772818527395" , 1234 , "Rovin" , "Sharma" , 10000.00));
        cardHolders.Add(new cardHolder("4532772818527595" , 4567 , "Rahul" , "Sharma" , 10000.00));
        cardHolders.Add(new cardHolder("4532772818527844" , 8011 , "Rohan" , "Sharma" , 10000.00));
        cardHolders.Add(new cardHolder("4532772818527145" , 9119 , "Anuj" , "Sharma" , 10000.00));
        cardHolders.Add(new cardHolder("4532772818527101" , 8055 , "Shivam" , "Sharma" , 10000.00));
        cardHolders.Add(new cardHolder("4532772818527001" , 9289 , "Sanjay" , "Sharma" , 10000.00));

        //Prompt User
        Console.WriteLine("Welcome To SimpeATM");
        Console.WriteLine("Please Insert Your Debit Card:");
        String debitcardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
               debitcardNum  = Console.ReadLine();
               //Check Our Database
               currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitcardNum);
               if (currentUser != null) { break; }
               else { Console.WriteLine("Card not recognised. Please try again.") ;}
            }

            catch{  Console.WriteLine("Card not recognised. Please try again.") ; }
        }

        Console.WriteLine("Please enter Your PIN:");
        int userpin = 0;
         while (true)
        {
            try
            {
               userpin = int.Parse(Console.ReadLine());
               //Check Our Database
               if (currentUser.getPin() == userpin) { break; }
               else { Console.WriteLine("Incorect PIN. Please try again.") ;}
            }

            catch{  Console.WriteLine("Incorect PIN. Please try again.") ; }
        }

        Console.WriteLine("Welcome" + currentUser.getFirstname() + "  :)");
        int option = 0;
        do
        {
            PrintOptions();
             try
             {
                option = int.Parse(Console.ReadLine());
             }
             catch{}
             if (option == 1){ deposit(currentUser); }
             else if (option == 2){ withdraw(currentUser); }
             else if (option == 3){ Balance(currentUser); }
             else if (option == 4){ break; }
             else  { option =0; }
        }
        while ( option!= 4 );
        Console.WriteLine("Thank You! Have a Nice Day :)");
      
    }
}
