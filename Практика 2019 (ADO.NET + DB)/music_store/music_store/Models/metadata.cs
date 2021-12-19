using System;
using System.ComponentModel.DataAnnotations;

namespace music_store.Models
{
    public class categoriesMetadata
    {
        [StringLength(50)]
        [Display(Name = "Название категории")]
        public string name;
    }

    public class usersaspMetadata
    {
        [StringLength(50)]
        [Display(Name = "Логин")]
        public string login;

        [StringLength(50)]
        [Display(Name = "Пароль")]
        public string password;

        [StringLength(50)]
        [Display(Name = "Имя")]
        public string name;
    }

    public class lotsMetadata
    {
        [StringLength(50)]
        [Display(Name = "Кол-во товара")]
        public string count;

        [StringLength(50)]
        [Display(Name = "Общая стоимость поставки")]
        public string cost;

        [StringLength(50)]
        [Display(Name = "Дата поставки")]
        public string date;
    }

    public class productsMetadata
    {
        [StringLength(50)]
        [Display(Name = "Название")]
        public string name;

        [StringLength(50)]
        [Display(Name = "Осталось")]
        public string count;

        [StringLength(50)]
        [Display(Name = "Вес")]
        public string weigh;

        [StringLength(50)]
        [Display(Name = "Цена")]
        public string price;

        [StringLength(300)]
        [Display(Name = "Описание")]
        public string description;

        [StringLength(50)]
        [Display(Name = "Фото")]
        public string image;
    }
    public class providersMetadata
    {
        [StringLength(50)]
        [Display(Name = "Производитель")]
        public string manufacturer;

        [StringLength(50)]
        [Display(Name = "Адрес")]
        public string address;

        [StringLength(50)]
        [Display(Name = "E-mail")]
        public string email;

        [StringLength(50)]
        [Display(Name = "Телефон")]
        public string tel_number;
    }

    public class salesMetadata
    {
        [StringLength(50)]
        [Display(Name = "Кол-во товара")]
        public string count;

        [StringLength(50)]
        [Display(Name = "Итоговая стоимость")]
        public string total_cost;

        [StringLength(50)]
        [Display(Name = "Дата")]
        public string date;
    }

    public class sellersMetadata
    {
        [StringLength(50)]
        [Display(Name = "ФИО")]
        public string fio;

        [StringLength(50)]
        [Display(Name = "Данные")]
        public string passport_info;

    }
}