﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace lucasvieiravicentenetcore.Models
{
    public class EmailViewModel
    {       
        [Required(ErrorMessage = "É necessário um nome")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "É necessário um E-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário um Telefone")]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "É necessário uma Mensagem")]
        [Display(Name = "Mensagem")]
        public string Body { get; set; }
    }
}