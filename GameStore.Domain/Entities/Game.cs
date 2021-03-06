﻿using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Domain.Entities
{
  
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue=false)]
        public int GameId { get; set; }

        [Display(Name="Название")]
        [Required(ErrorMessage="Пожалуйста, введите название игры")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name="Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание для игры")]
        public string Description { get; set; }

        [Display(Name = "Жанр")]
        [Required(ErrorMessage = "Пожалуйста, укажите жанр игры")]
        public string Genre { get; set; }

        [Display(Name = "Издатель")]
        [Required(ErrorMessage = "Пожалуйста, укажите издателя игры")]
        public string Author { get; set; }

        [Display(Name = "Цена (руб)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
