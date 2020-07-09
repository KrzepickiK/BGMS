using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGMS_Repository.Model
{
    public class GameModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinPlayersNum { get; set; }
        public int MaxPlayersNum { get; set; }
        public int MinimalPlayerAge { get; set; }

        public virtual List<GameDisplayinformationModel> GameDisplays { get; set; }
    }
   
}
