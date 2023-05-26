using System;

namespace Cars.Domain
{
    public class Car
    {
        public Guid UserId { get; set; }//Юзерайди
        public Guid Id { get; set; }//Айди
        public string Title { get; set; }//Название машины
        public string Details { get; set; }//Внешнее описание
        public string Country { get; set; }//Страна
        public int UsageBenzin { get; set; }//Использование бензина
        public int SerialNumber { get; set; }//Серийный номер авто
        public DateTime CreationDate { get; set; }//Время создания
        public DateTime? EditDate { get; set; }
    }
}
