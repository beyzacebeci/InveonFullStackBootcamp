using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Author).IsRequired();

            builder.HasData(
    new Book() { Id = 1, Title = "Beyaz Gemi", Author = "Cengiz Aytmatov", ISBN = "9789750808132", Genre = "Roman", Publisher = "Can Yayınları", PageCount = 160, Language = "Türkçe", Summary = "Issık-Göl çevresinde geçen bir çocuğun hikayesi.", AvailableCopies = 5, PublicationYear = 1970 },
    new Book() { Id = 2, Title = "Deniz Kurdu", Author = "Jack London", ISBN = "9786053606331", Genre = "Macera", Publisher = "İş Bankası Kültür Yayınları", PageCount = 432, Language = "Türkçe", Summary = "Kaptan Larsen ve denizcilik üzerine etkileyici bir roman.", AvailableCopies = 3, PublicationYear = 1904 },
    new Book() { Id = 3, Title = "Tutunamayanlar", Author = "Oğuz Atay", ISBN = "9789754700111", Genre = "Roman", Publisher = "İletişim Yayınları", PageCount = 724, Language = "Türkçe", Summary = "Türk edebiyatında bir başyapıt.", AvailableCopies = 7, PublicationYear = 1972 },
    new Book() { Id = 4, Title = "Savaş ve Barış", Author = "Lev Tolstoy", ISBN = "9789754587095", Genre = "Tarih", Publisher = "Türkiye İş Bankası Yayınları", PageCount = 1600, Language = "Türkçe", Summary = "Napolyon döneminde Rusya ve insanlık üzerine bir roman.", AvailableCopies = 4, PublicationYear = 1869 },
    new Book() { Id = 5, Title = "1984", Author = "George Orwell", ISBN = "9789750718530", Genre = "Distopya", Publisher = "Can Yayınları", PageCount = 352, Language = "Türkçe", Summary = "Baskıcı bir rejim üzerine karanlık bir roman.", AvailableCopies = 6, PublicationYear = 1949 },
    new Book() { Id = 6, Title = "Küçük Prens", Author = "Antoine de Saint-Exupéry", ISBN = "9786053606478", Genre = "Çocuk", Publisher = "Can Çocuk Yayınları", PageCount = 96, Language = "Türkçe", Summary = "Bir çocuğun evreni keşfetme hikayesi.", AvailableCopies = 10, PublicationYear = 1943 },
    new Book() { Id = 7, Title = "Don Quijote", Author = "Miguel de Cervantes", ISBN = "9789754587404", Genre = "Roman", Publisher = "Türkiye İş Bankası Yayınları", PageCount = 1600, Language = "Türkçe", Summary = "Rüzgar değirmenleriyle savaşan bir şövalyenin hikayesi.", AvailableCopies = 2, PublicationYear = 1605 },
    new Book() { Id = 8, Title = "Simyacı", Author = "Paulo Coelho", ISBN = "9789750718482", Genre = "Felsefi Roman", Publisher = "Can Yayınları", PageCount = 184, Language = "Türkçe", Summary = "Bir çobanın hazinesi için çıktığı yolculuk.", AvailableCopies = 8, PublicationYear = 1988 },
    new Book() { Id = 9, Title = "Hayvan Çiftliği", Author = "George Orwell", ISBN = "9789750718895", Genre = "Allegori", Publisher = "Can Yayınları", PageCount = 152, Language = "Türkçe", Summary = "Bir çiftlikteki hayvanların insanlaşmasını anlatan alegori.", AvailableCopies = 9, PublicationYear = 1945 },
    new Book() { Id = 10, Title = "Anna Karenina", Author = "Lev Tolstoy", ISBN = "9789754587442", Genre = "Roman", Publisher = "Türkiye İş Bankası Yayınları", PageCount = 864, Language = "Türkçe", Summary = "Aşk ve insan doğası üzerine bir başyapıt.", AvailableCopies = 4, PublicationYear = 1877 }
);


        }
    }
}
