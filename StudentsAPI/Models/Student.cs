namespace StudentsAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Patronymic { get; set; }
        public Nullable<bool> Sex { get; set; }
        public string AcademicGroupNumber { get; set; }
        public string PhotoURL { get; set; }
        public string Skills { get; set; }
        public string TEMA_DIPLOMA { get; set; }
    }
}
