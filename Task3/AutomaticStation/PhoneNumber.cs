using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AutomaticStation
{
    public class PhoneNumber : IEquatable<PhoneNumber>
    {
        private readonly string _phoneNumber;
        public string Value
        {
            get { return _phoneNumber; }
        }
        public override string ToString()
        {
            return Value;
        }


        public PhoneNumber (string phoneNumber)
        {
            if (Regex.IsMatch(phoneNumber, @"\d{9}"))
                _phoneNumber = String.Format("{0}-(1}-{2}-{3}", phoneNumber.Substring(0, 2),
                                                                phoneNumber.Substring(2, 3),
                                                                phoneNumber.Substring(5, 2),
                                                                phoneNumber.Substring(7, 2)
                                            );
            else if (Regex.IsMatch(phoneNumber, @"\d{2}-\d{3}-\d{2}-\d{2}"))
                _phoneNumber = phoneNumber;
            else
                throw new FormatException("The phone number has an invalid format.");

            _phoneNumber = phoneNumber;
        }

        public bool Equals(PhoneNumber other)
        {
            if (other == null)
                return false;

            if (this._phoneNumber == other._phoneNumber)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            PhoneNumber phoneNumberObj = obj as PhoneNumber;
            if (phoneNumberObj == null)
                return false;
            else
                return Equals(phoneNumberObj);
        }

        public override int GetHashCode()
        {
            return _phoneNumber.GetHashCode();
        }

        public static bool operator == (PhoneNumber phoneNumber1, PhoneNumber phoneNumber2)
        {
            if (((object)phoneNumber1) == null || ((object)phoneNumber2) == null)
                return Object.Equals(phoneNumber1, phoneNumber2);

            return phoneNumber1.Equals(phoneNumber2);
        }

        public static bool operator !=(PhoneNumber phoneNumber1, PhoneNumber phoneNumber2)
        {
            if (((object)phoneNumber1) == null || ((object)phoneNumber2) == null)
                return !Object.Equals(phoneNumber1, phoneNumber2);

            return !(phoneNumber1.Equals(phoneNumber2));
        }
        }
}