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
        public string allPhones;
        public string allEmail;
        public string allDetails;
        public string fullNameNicknameblock;
        public string titleCompAddrBlock;
        public string phonesBlock;
        public string emailHomepageBlock;
        public string birthAnnivBlock;
        public string secondaryBlock;

        public ContactData()
        {

        }


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
            return "Firstname=" + Firstname + "\nMiddlename= " + Middlename + "\nLastname= " + Lastname;
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
                    return fieldName + FullDate + " (" + Age + ")";
                }
                else
                {
                    return fieldName + FullDate;
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
                if (year != null && year != "")
                {
                    return fieldName + FullDate + " (" + Anniversary + ")";
                }
                else
                {
                    return fieldName + FullDate;
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
                string fullNameBlock = FullNameNicknameblock;
                string titleBlock = TitleCompAddrBlock;
                string phoneBlock = PhonesBlock;
                string emailBlock = EmailHomepageBlock;
                string dateBlock = BirthAnnivBlock;
                string secondaryBlock = SecondaryBlock;
                string allDetails2 = "";



                if (allDetails != null)
                {
                    return allDetails = "";
                }
                else
                {
                    if (fullNameBlock != "")
                    {
                        allDetails2 = fullNameBlock;
                    }
                    if (titleBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNabove(titleBlock);
                        }
                        else
                        {
                            allDetails2 = titleBlock;
                        }
                    }
                    if (phoneBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(phoneBlock);
                        }
                        else
                        {
                            allDetails2 = phoneBlock;
                        }
                    }
                    if (emailBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(emailBlock);
                        }
                        else
                        {
                            allDetails2 = emailBlock;
                        }
                    }
                    if (dateBlock != null && dateBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(dateBlock);
                        }
                        else
                        {
                            allDetails2 = dateBlock;
                        }
                    }
                    else 
                        if (secondaryBlock != "" && secondaryBlock != "P:")
                    {
                        allDetails2 += "\r\n";

                    }
                    if (secondaryBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(secondaryBlock);
                        }
                        else
                        {
                            allDetails2 = secondaryBlock;
                        }
                    }
                }
                return allDetails2.Trim();
            }
            set
            {
                allDetails = value;
            }
        }

        public string FullNameNicknameblock
        {
            get
            {
                string fullNameNicknameblock = "";
                string fullName = ReturnFullName(Firstname.Trim(), Middlename.Trim(), Lastname.Trim());
                if (fullName != null && fullName != "")
                {
                    fullNameNicknameblock = fullName.Trim();
                }
                if (Nickname != null && Nickname != "")
                {
                    if (fullNameNicknameblock != null && fullNameNicknameblock != "")
                    {
                        fullNameNicknameblock += "\r\n" + Nickname.Trim();
                    }
                    else
                    {
                        fullNameNicknameblock = Nickname.Trim();
                    }
                }
                return fullNameNicknameblock;
            }
            set
            {
                fullNameNicknameblock = value;
            }
        }

        public string TitleCompAddrBlock
        {
            get
            {
                string titleCompAddrBlock = "";
                if (Title != null && Title != "")
                {
                    titleCompAddrBlock = Title.Trim();
                }
                if (Company != null && Company != "")
                {
                    if (titleCompAddrBlock != null && titleCompAddrBlock != "")
                    {
                        titleCompAddrBlock += "\r\n" + Company.Trim();
                    }
                    else
                    {
                        titleCompAddrBlock = Company.Trim();
                    }
                }
                if (Address != null && Address != "")
                {
                    if (titleCompAddrBlock != null && titleCompAddrBlock != "")
                    {
                        titleCompAddrBlock += "\r\n" + Address.Trim();
                    }
                    else
                    {
                        titleCompAddrBlock = Address.Trim();
                    }
                }
                return titleCompAddrBlock;
            }
            set
            {
                titleCompAddrBlock = value;
            }
        }

        public string PhonesBlock
        {
            get
            {
                string phonesBlock = "";

                if (HomePhone != null && HomePhone != "")
                {
                    phonesBlock = ("H: " + HomePhone.Trim()).Trim();
                }
                if (MobilePhone != null && MobilePhone != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("M: " + MobilePhone.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("M: " + MobilePhone.Trim()).Trim();
                    }
                }
                if (WorkPhone != null && WorkPhone != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("W: " + WorkPhone.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("W: " + WorkPhone.Trim()).Trim();
                    }
                }
                if (Fax != null && Fax != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("F: " + Fax.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("F: " + Fax.Trim()).Trim();
                    }
                }
                return phonesBlock;
            }
            set
            {
                phonesBlock = value;
            }
        }

        public string EmailHomepageBlock
        {
            get
            {
                string emailHomepageBlock = "";

                if (Email != null && Email != "")
                {
                    emailHomepageBlock = Email;
                }
                if (Email2 != null && Email2 != "")
                {
                    if (emailHomepageBlock != null && emailHomepageBlock != "")
                    {
                        emailHomepageBlock = emailHomepageBlock.Trim() + "\r\n" + Email2.Trim();
                    }
                    else
                    {
                        emailHomepageBlock = Email2;
                    }
                }
                if (Email3 != null && Email3 != "")
                {
                    if (emailHomepageBlock != null && emailHomepageBlock != "")
                    {
                        emailHomepageBlock = emailHomepageBlock + "\r\n" + Email3.Trim();
                    }
                    else
                    {
                        emailHomepageBlock = Email3;
                    }
                }
                if (Homepage != null && Homepage != "")
                {
                    if (emailHomepageBlock != null && emailHomepageBlock != "")
                    {
                        emailHomepageBlock = emailHomepageBlock + "\r\n" + "Homepage:\r\n" + Homepage.Trim();
                    }
                    else
                    {
                        emailHomepageBlock = "Homepage:\r\n" + Homepage.Trim();
                    }
                }
                return emailHomepageBlock;
            }
            set
            {
                emailHomepageBlock = value;
            }
        }

        public string BirthAnnivBlock
        {
            get
            {
                string bithString = GetAge(BDay, BMonth, BYear, "Birthday ");
                string annivString = GetAnniversary(ADay, AMonth, AYear, "Anniversary ");
                string birthAnnivBlock = "";

                if (bithString != null && bithString != "")
                {
                    birthAnnivBlock = bithString.Trim();
                }
                if (annivString != null && annivString != "")
                {
                    if (birthAnnivBlock != null && birthAnnivBlock != "")
                    {
                        birthAnnivBlock += "\r\n" + annivString.Trim();
                    }
                    else
                    {
                        birthAnnivBlock = annivString.Trim();
                    }
                }
                return birthAnnivBlock;
            }
            set
            {
                birthAnnivBlock = value;
            }
        }

        public string SecondaryBlock
        {
            get
            {
                string secondaryBlock = "";
                if (Address2.Trim() != null && Address2.Trim() != "")
                {
                    secondaryBlock = Address2.Trim();
                }
                if (Phone2 != null && Phone2 != "")
                {
                    if (secondaryBlock != null && secondaryBlock != "")
                    {
                        secondaryBlock += "\r\n\r\n" + ("P: " + Phone2.Trim()).Trim();
                    }
                    else
                    {
                        secondaryBlock = "\r\n" + ("P: " + Phone2.Trim()).Trim();
                    }
                }
                if (Notes.Trim() != null && Notes.Trim() != "")
                {
                    if (secondaryBlock != null && secondaryBlock != "")
                    {
                        secondaryBlock += "\r\n\r\n" + Notes.Trim();
                    }
                    else
                    {
                        secondaryBlock = Notes.Trim();
                    }
                }
                return secondaryBlock;
            }
            set
            {
                secondaryBlock = value;
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

        public string ReturnDetailwithoutRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text;
        }

        public string ReturnDetailwithRNabove(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n" + text;
        }

        public string ReturnDetailwithRNRNabove(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n\r\n" + text;
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

            return FullName;
        }

    }
}
