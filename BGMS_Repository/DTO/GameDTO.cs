using BGMS_Repository.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGMS_Repository.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }

        [DisplayName("Game name")]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [DisplayName("Min players")]
        [Range(1, int.MaxValue)]
        [NumericLessThan("MaxPlayersNum", AllowEquality = true)]
        [Required]
        public int MinPlayersNum { get; set; }

        [DisplayName("Max players")]
        [Range(1, int.MaxValue)]
        [Required]
        public int MaxPlayersNum { get; set; }

        [DisplayName("Minimal recommended player age")]
        [Range(0, 99)]
        [Required]
        public int MinimalPlayerAge { get; set; }
    }

    public class GameDetailsDTO : GameDTO
    {
        [DisplayName("Last views of that game")]
        public ICollection<GameDisplayInformationDTO> LastDisplays { get; set; }
    }

    public class GameListDTO
    {
        public GameListDTO()
        {
            this.GenerateDateTime = DateTime.Now;
        }

        public DateTime GenerateDateTime { get; set; }
        public int GamesQty => this.Games.Count();
        public ICollection<GameDTO> Games { get; set; }
    }

    public class GameDisplayInformationDTO
    {
        public int GameId { get; set; }
        public DateTime DisplayTime { get; set; }

        [DisplayName("Display source")]
        public string DisplaySource { get; set; }

        [DisplayName("Display time")]
        public string DisplayTimeFormatted
        {
            get
            {
                return this.DisplayTime.ToShortTimeString();
            }
        }

        [DisplayName("Display date")]
        public string DisplayDateFormatted
        {
            get
            {
                return this.DisplayTime.ToShortDateString();
            }
        }
    }
}
