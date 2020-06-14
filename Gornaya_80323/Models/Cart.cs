using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gornaya_80323.DAL;

namespace Gornaya_80323.Models
{
    public class CartItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        Dictionary<int, CartItem> cartItems;
        public Cart()
        {
            cartItems = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Добавить в корзину
        /// </summary>
        /// <param name="dish">объект для добавления</param>
        public void AddItem(Book book)
        {
            if (cartItems.ContainsKey(book.BookId))
                cartItems[book.BookId].Quantity += 1;
            else
                cartItems.Add(book.BookId,
                new CartItem { Book = book, Quantity = 1 });
        }
        /// <summary>
        /// Удалить из корзины
        /// </summary>
        /// <param name="dish">Объект для удаления</param>
        public void RemoveItem(Book book)
        {
            if (cartItems[book.BookId].Quantity == 1)
                cartItems.Remove(book.BookId);
            else
                cartItems[book.BookId].Quantity -= 1;
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void Clear()
        {
            cartItems.Clear();
        }
        /// <summary>
        /// Получение стоимости книг
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            return cartItems
            .Values
            .Sum(i => i.Book.BookPrice * i.Quantity);
        }
        /// <summary>
        /// Получение содержимого корзины
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CartItem> GetItems()
        {
            return cartItems.Values;
        }
    }
}