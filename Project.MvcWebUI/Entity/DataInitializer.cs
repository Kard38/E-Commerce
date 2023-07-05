using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.MvcWebUI.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>() 
            {
                new Category() { Name = "Kamera", Description= "Kamera ürünleri"},
                new Category() { Name = "Bilgisayar", Description= "Bilgisayar ürünleri"},
                new Category() { Name = "Elektronik", Description= "Elektronik ürünleri"},
                new Category() { Name = "Telefon", Description= "Telefon ürünleri"},
                new Category() { Name = "Beyaz Eşya", Description= "Beyaz Eşya ürünleri"},
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori); 
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){Name="kamera1",Description="kamera1desc",Price=1000,Stock=10 ,IsApproved= true ,CategoryId=1,IsHome=true,Image = "1.jpg"},
                new Product(){Name="kamera2",Description="kamera2desc",Price=2000,Stock=20 ,IsApproved= true ,CategoryId=1,IsHome=true,Image = "2.jpg"},
                new Product(){Name="kamera3",Description="kamera3desc",Price=3000,Stock=30 ,IsApproved= true ,CategoryId=1,Image = "3.jpg"},
                new Product(){Name="kamera4",Description="kamera4desc",Price=4000,Stock=40 ,IsApproved= true ,CategoryId=1,Image = "4.jpg"},
                new Product(){Name="kamera5",Description="kamera5desc",Price=5000,Stock=50 ,IsApproved= true ,CategoryId=1,Image = "5.jpg"},
         
                new Product(){Name="pc1",Description="pc1desc",Price=110,Stock=11 ,IsApproved=false ,CategoryId=2,Image = "1.jpg"},
                new Product(){Name="pc2",Description="pc2desc",Price=210,Stock=21 ,IsApproved=false ,CategoryId=2,Image = "2.jpg"},
                new Product(){Name="pc3",Description="pc3desc",Price=310,Stock=31 ,IsApproved=false ,CategoryId=2,Image = "3.jpg"},
                new Product(){Name="pc4",Description="pc4desc",Price=410,Stock=41 ,IsApproved=false ,CategoryId=2,IsHome=true,Image = "4.jpg"},
                new Product(){Name="pc5",Description="pc5desc",Price=510,Stock=51 ,IsApproved=false ,CategoryId=2,IsHome=true,Image = "5.jpg"},
               

                new Product(){Name="tel1",Description="tel1desc",Price=111,Stock=111 ,IsApproved=true ,CategoryId=4,IsHome=true,Image = "1.jpg"},
                new Product(){Name="tel2",Description="tel2desc",Price=222,Stock=222 ,IsApproved=true ,CategoryId=4,IsHome=true,Image = "2.jpg"},
                new Product(){Name="tel3",Description="tel3desc",Price=333,Stock=333 ,IsApproved=true ,CategoryId=4,IsHome=true,Image = "3.jpg"},
                new Product(){Name="tel4",Description="tel4desc",Price=444,Stock=444 ,IsApproved=true ,CategoryId=4,Image = "4.jpg"},
                new Product(){Name="tel5",Description="tel5desc",Price=555,Stock=555 ,IsApproved=true ,CategoryId=4,Image = "5.jpg"},
            
            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}