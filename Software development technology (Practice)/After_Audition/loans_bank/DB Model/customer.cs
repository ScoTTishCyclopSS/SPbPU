//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace loans_bank
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer
    {
        public int customer_id { get; set; }
        public string fio { get; set; }
        public string passport_number { get; set; }
        public System.DateTime passport_date { get; set; }
        public string passport_info { get; set; }
        public string sex { get; set; }
        public string family_status { get; set; }
        public System.DateTime birthdate { get; set; }
        public string tel_number { get; set; }
        public string email { get; set; }
        public string education { get; set; }
        public string education_place_code { get; set; }
        public string live_place { get; set; }
        public string work_place { get; set; }
        public string work_tel_number { get; set; }
        public string work_post { get; set; }
        public string month_income { get; set; }
        public string credit_reason { get; set; }
    
        public virtual credit credit { get; set; }
    }
}
