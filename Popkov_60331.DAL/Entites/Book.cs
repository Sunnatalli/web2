using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Gornaya_80323.DAL
{
    public class Book
    {
        [HiddenInput]
        public int BookId { get; set; } //идентификатор книги

        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название книги")]
        public string BookTitle { get; set; } //название книги

        [Required(ErrorMessage = "Введите автора")]
        [Display(Name = "Автор книги")]
        public string BookAuthor { get; set; } //автор книги

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание книги")]
        public string Description { get; set; } //описание книги

        [Required]
        [Display(Name = "Жанр")]
        public string BookType { get; set; } //жанр книги (историческая, роман, детектив и т.д.)

        [Required]
        [Range(minimum: 1, maximum: 1000)]
        public int BookPrice { get; set; } //цена книги

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; } // данные изображения

        [ScaffoldColumn(false)]
        public string MimeType { get; set; } // Mime - тип данных изображения
    }
}
