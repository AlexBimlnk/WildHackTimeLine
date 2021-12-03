using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WildHackWebApp.Models
{

    /// <summary>
    /// Экологическое событие
    /// </summary>
    public class EcologyEvent
    {
        /// <summary>
        /// Id экологического события.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название события.
        /// </summary>
        public string Title { get; set; }
        ///<summary>
        ///Дата события
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Описание события.
        /// </summary>
        public string Description { get; set; }
    }
}
