﻿using System;

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
        private string phoneNumber;
        public static int numberOfCustomers = 0;

        //Constructor(s)
        public Customer(string firstName, string lastName, string phoneNumber)
        {
            this.custID = numberOfCustomers;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            numberOfCustomers++;
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
        public string PhoneNumber
        {
            get {return phoneNumber;}
            set {phoneNumber = value;}
        }

        //Member Methods 
    }
}
