using System.IO;
using System.Collections.Generic;
using System.Text;

namespace BeerBot_1
{
    public class Media
    {
        public string TitleName { get; set; }
        public string Descripton { get; set; }
        public double Review { get; set; }
        public int UsersReviewed { get; set; }
        public string PicURL { get; set; }

        public Media(string titleName, string descripton, double review, int usersReviewed, string picURL)
        {
            TitleName = titleName;
            Descripton = descripton;
            Review = review;
            UsersReviewed = usersReviewed;
            PicURL = picURL;
        }
    }
}
