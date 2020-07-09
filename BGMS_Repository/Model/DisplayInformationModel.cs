using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGMS_Repository.Model
{
    public abstract class DisplayInformationModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DisplayTime { get; set; }
        public string DisplaySource { get; set; }
    }

    public class GameDisplayinformationModel : DisplayInformationModel
    {
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual GameModel Game { get; set; }
    }

}
