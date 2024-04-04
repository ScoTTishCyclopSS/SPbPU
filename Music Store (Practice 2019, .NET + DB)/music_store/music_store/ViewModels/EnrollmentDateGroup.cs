using System;
using System.ComponentModel.DataAnnotations;

namespace music_store.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)] public DateTime? EnrollmentDate { get; set; }

        public int salescount { get; set; }
    }
}