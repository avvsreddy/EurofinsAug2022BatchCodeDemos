namespace DelegatesDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account acc1 = new Account();
            acc1.alert += Notification.SendEmail;
            //acc1.Subscribe(Notification.SendEmail);
            acc1.alert += Notification.SendSMS;
            acc1.alert += Notification.SendWhatsApp;
            acc1.alert -= Notification.SendEmail;
            //acc1.Subscribe(Notification.SendSMS);
            //acc1.Unsubscribe(Notification.SendEmail);
            //acc1.alert("Credited $99999999999999999999999999.00");
            System.Console.WriteLine($"Initial Balance : {acc1.Balance}");
            //acc1.Deposit(5000);
            System.Console.WriteLine($"After Deposit Balance : {acc1.Balance}");
            //acc1.Withdraw(1000);
            System.Console.WriteLine($"After Withdraw Balance : {acc1.Balance}");


        }
    }


    // declare the delegate
    public delegate void Alert(string msg);

    class Account
    {
        public int Balance { get; private set; }
        public event Alert alert = null; //new Alert(Notification.SendEmail);
        //public void Subscribe(Alert alert)
        //{
        //    this.alert += alert;
        //}
        //public void Unsubscribe(Alert alert)
        //{
        //    this.alert -= alert;
        //}

        public void Deposit(int amount)
        {
            Balance += amount;
            if (alert != null)
                alert($"Credited {amount}");
        }
        public void Withdraw(int amount)
        {
            Balance -= amount;
            if (alert != null)
                alert($"Debited {amount}");
        }
    }


    public class Notification
    {
        public static void SendEmail(string msg)
        {
            //SmtpClient
            //MailMessage
            System.Console.WriteLine($"MAIL: {msg}");
        }

        public static void SendSMS(string msg)
        {
            //SmtpClient
            //MailMessage
            System.Console.WriteLine($"SMS: {msg}");
        }
        public static void SendWhatsApp(string msg)
        {
            //SmtpClient
            //MailMessage
            System.Console.WriteLine($"Whats App: {msg}");
        }

    }
}
