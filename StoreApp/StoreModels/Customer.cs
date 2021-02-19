using System;

namespace StoreModels
{
    /// <summary>
    /// This class contains all the necessary properties and fields for customer information
    /// </summary>
    public class Customer
    {
        //Data Fields
        private int custID;
        private string firstName;
        private string lastName;
        private int phoneNumber;

        //Constructor(s)
        public Customer(int custID, string firstName, string lastName, int phoneNumber)
        {
            this.custID = custID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }

        //Properties
        public int CustID
        {
            get {return custID;}
            set {custID = value;}
        }
        public string FirstName
        {
            get {return firstName;}
            set { firstName = value;}
        }
        public string LastName
        {
            get {return lastName;}
            set {lastName = value;}
        }
        public int PhoneNumber
        {
            get {return phoneNumber;}
            set {phoneNumber = value;}
        }

        //Member Methods 
    }
}
