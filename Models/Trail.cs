using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ParkFinder.Models
{
    public class Trail
    {
        public  int id{get;set;}
        [Required]
        [Display(Name="Trail Name")]
        [MinLength(5,ErrorMessage="Trail Name should be atleast 5 characters")]
        public string name{get;set;}

        [Required(ErrorMessage="Trail Length is required")]
        [Display(Name="Trail Length")]
        [RegularExpression(@"^[+-]?([0-9]*[.])?[0-9]+$",ErrorMessage="Length should be a number")]
        public double trailLength{get;set;}

        [Required(ErrorMessage="Elevation is required")]
        [Display(Name="Elevation")]
        [RegularExpression(@"^\d+$",ErrorMessage="Elevation should be a number")]
        public int elevation{get;set;}

        [Required]
        [Display(Name="Decription")]
        [MinLength(10,ErrorMessage="Trail Name should be atleast 10 characters")]
        public string description{get;set;}

        [Required(ErrorMessage="Longtitude is required")]
        [Display(Name="Longtitude")]
        [RegularExpression(@"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?)$",ErrorMessage="Longtitude should be a correct format")]
        public double longtitude{get;set;}
        

        [Required(ErrorMessage="Latitude is required")]
        [Display(Name="Latitude")]
        [RegularExpression(@"[-+]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+)?)$",ErrorMessage="Latitude should be a correct format")]
        public double latitude{get;set;}
    }
}