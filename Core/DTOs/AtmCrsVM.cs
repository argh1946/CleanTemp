using Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Core.DTOs
{    
    public class AtmCrsVM
    {
        public int Id { get; set; }      
        public string Title { get; set; }       
        public string Code { get; set; }        
        public string StateName { get; set; }        
        public string CityName { get; set; }        
        public string Location { get; set; }      
        public string Address { get; set; }       
        public string Model { get; set; }       
        public string Type { get; set; }
    }
}
