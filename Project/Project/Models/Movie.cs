using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
       
        public string Description { get; set; }
        public Double Price { get; set; }
        public string ImageURl { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public MovieCategory MovieCategory { get; set; }
        //Relationship
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

    }
}
