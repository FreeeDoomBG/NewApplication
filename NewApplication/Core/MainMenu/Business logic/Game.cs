using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApplication
{
    public class Game
    {
        [Key]
        //ID на игра
        public int EmpID { get; set; }
        [StringLength(255)]
        //Име на играта
        public string Name { get; set; }
        [StringLength(255)]
        //Измерение на играта
        //public string Dimension { get; set; }
        //[StringLength(255)]
        //Имейл на разработчика
        public string Email { get; set; }
        [StringLength(255)]
        //Дата на създаване
        public string Dob { get; set; }
        [StringLength(255)]
        //Жанр на играта (Фентъзи, стратегия, ММО, стрелба)
        public string Genera { get; set; }
        //Описание на играта - Text
        public string Text { get; set; }
        //URL за достъп до снимката с 
        //логото на играта на първи слот
        public string ImageUrl { get; set; }
        //URL за достъп до снимката на втори основен слот
        public string ImageUrl1 { get; set; }
        //URL за достъп до снимката на трети слот
        public string ImageUrl2 { get; set; }
        //URL за достъп до снимката на четвърти слот
        public string ImageUrl3 { get; set; }
        //URL за достъп до снимката на пети слот
        public string ImageUrl4 { get; set; }

    }
}
