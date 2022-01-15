using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail;
        private string allDetails;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode() & Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return $"contact = {Lastname} {Firstname}";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.Firstname != other.Firstname)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            if (this.Lastname != other.Lastname)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return 0;
        }

        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string BYear { get; set; }
        public string ADay { get; set; }
        public string AMonth { get; set; }
        public string AYear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }
        public string SecondaryAddress { get; set; }
        public string SecondaryHome { get; set; }
        public string SecondaryNotes { get; set; }
        public string FullName { get; set; }

        public string GetAge(string day, string month, string year, string fieldName)
        {
            int monthNumber = 0;
            int Age;
            switch (month)
            {
                case "January":
                    monthNumber = 1;
                    break;
                case "February":
                    monthNumber = 2;

                    break;
                case "March":
                    monthNumber = 3;

                    break;
                case "April":
                    monthNumber = 4;

                    break;
                case "May":
                    monthNumber = 5;

                    break;
                case "June":
                    monthNumber = 6;

                    break;
                case "July":
                    monthNumber = 7;

                    break;
                case "August":
                    monthNumber = 8;

                    break;
                case "September":
                    monthNumber = 9;

                    break;
                case "October":
                    monthNumber = 10;

                    break;
                case "November":
                    monthNumber = 11;

                    break;
                case "December":
                    monthNumber = 12;

                    break;
            }
            if (year != "")
            {
                if ((DateTime.Now.Month >= monthNumber) && (DateTime.Now.Day >= Int32.Parse(day)))
                    Age = DateTime.Now.Year - Int32.Parse(year);
                else
                    Age = DateTime.Now.Year - Int32.Parse(year) - 1;
            }
            else Age = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (month != null && month != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + month;
                }
                else
                {
                    FullDate = month;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != "")
                {
                    return fieldName + FullDate + " (" + Age + ")\r\n";
                }
                else
                {
                    return fieldName + FullDate + "\r\n";
                }
            }
            else return "";
        }

        public string GetAnniversary(string day, string month, string year, string fieldName)
        {
            int Anniversary;
            if (year != "")
                Anniversary = DateTime.Now.Year - Int32.Parse(year);
            else
                Anniversary = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (month != null && month != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + month;
                }
                else
                {
                    FullDate = month;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != "")
                {
                    return fieldName + FullDate + " (" + Anniversary + ")\r\n";
                }
                else
                {
                    return fieldName + FullDate + "\r\n";
                }
            }
            else return "";
        }


        public string AllPhones 
        { 
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (ReturnDetailwithRN(Email) + ReturnDetailwithRN(Email2) + ReturnDetailwithRN(Email3)).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    return (ReturnFullName(Firstname, Middlename, Lastname) + ReturnDetailwithRN(Nickname) + "\r\n"
                        + ReturnDetailwithRN(Title)
                        + ReturnDetailwithRN(Company)
                        + ReturnDetailwithRN(Address) + "\r\n" 
                        + ReturnDetailwithRN(HomePhone, "H: ")
                        + ReturnDetailwithRN(MobilePhone, "M: ")
                        + ReturnDetailwithRN(WorkPhone, "W: ")
                        + ReturnDetailwithRN(Fax, "F: ") + "\r\n"
                        + ReturnDetailwithRN(Email)
                        + ReturnDetailwithRN(Email2)
                        + ReturnDetailwithRN(Email3)
                        + ReturnDetailwithRN(Homepage, "Homepage:\r\n") + "\r\n"
                        + GetAge(BDay, BMonth, BYear, "Birthday ") 
                        + GetAnniversary(ADay, AMonth, AYear, "Anniversary ") + "\r\n"
                        + ReturnDetailwithRN(Address2) + "\r\n"
                        + ReturnDetailwithRN(Phone2, "P: ") + "\r\n"
                        + ReturnDetailwithoutBr(Notes));

                }
            }
            set
            {
                allDetails = value;
            }
        }

        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n";
        }

        public string ReturnDetailwithRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";
        }


        public string ReturnDetailwithRN(string text, string fieldName)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return fieldName + text + "\r\n";
        }

        public string ReturnDetailwithoutBr(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text;
        }


        public string ReturnFullName(string name, string middlename, string lastname )
        {
            string FullName = "";
            if (name != null && name != "")
            {
                FullName = name;
            }
            if (middlename != null && middlename != "")
            {
               if (FullName != "")
                {
                    FullName += " " + middlename;
                }
               else
                {
                    FullName = middlename;
                }
            }
            if (lastname != null && lastname != "")
            {
                if (FullName != "")
                {
                    FullName += " " + lastname;
                }
                else
                {
                    FullName = lastname;
                }
            }

            return FullName + "\r\n";
        }

    }
}
