using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WPF_Demo
{
    public class Lead
    {
        public string Lname { get; set; }

        public string LProject_Name { get; set; }

        public string LStatus { get; set; }

        public string LAdded { get; set; }

        public string LType { get; set; }

        public string LContact { get; set; }

        public string LAction { get; set; }

        public string LAssignee { get; set; }

        public string LBid_Date { get; set; }
        [Key]
        public int Lid { get; set; }

       
    }
}
