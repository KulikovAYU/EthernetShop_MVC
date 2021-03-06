﻿using System;

namespace GameStore.WebUI.Models
{
    //(модель представления) класс между передачи между конгтроллером и представлением
    public class PagingInfo
    {
        // Кол-во товаров
        public int TotalItems { get; set; }
        // Кол-во товаров на одной странице
        public int ItemsPerPage { get; set; }
        // Номер текущей страницы
        public int CurrentPage { get; set; }
        // Общее кол-во страниц
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}