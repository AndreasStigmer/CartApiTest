using CartApi.Services;
using System;

namespace CartApi.Models
{
    public class MasterCard : ICard
    {
        public MasterCard(string cardnumber,string name,DateTime validTo)
        {
            this.CardNumber= cardnumber;
            this.Name = name;
            this.ValidTo = validTo;

        }
        public string CardNumber { get; set ; }
        public string Name { get; set ; }
        public DateTime ValidTo { get; set; }
    }
}
