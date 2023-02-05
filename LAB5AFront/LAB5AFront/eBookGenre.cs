using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LAB5AFront
{
    public enum eBookGenre
    {
        [Display(Name = "Fantasy")]
        Fantasy,

        [Display(Name = "SciFi")]
        SciFi,

        [Display(Name = "Kryminalne")]
        Mystery,

        [Display(Name = "Thriller")]
        Thriller,

        [Display(Name = "Romans")]
        Romance,

        [Display(Name = "Popularnonaukowe")]
        PopularnoNaukowe,

        [Display(Name = "Naukowe")]
        Naukowe
    }
}
