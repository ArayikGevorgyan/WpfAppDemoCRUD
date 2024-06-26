﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppDemoCRUD.Data;

namespace WpfAppDemoCRUD
{
     // Main window class
    public partial class MainWindow : Window
    {
        ProductDbContext dbContext;
        Product NewProduct = new Product();

        public MainWindow(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            GetProducts();

            AddNewProductGrid.DataContext = NewProduct;
            
        }
        
        // Method to fetch products from the database
        private void GetProducts()
        {
            ProductDG.ItemsSource = dbContext.Products.ToList();
        }
        
        // Event handler to add a new product
        private void AddProduct(object s, RoutedEventArgs e)
        {
            dbContext.Products.Add(NewProduct);
            dbContext.SaveChanges();
            GetProducts();
            NewProduct = new Product();
            AddNewProductGrid.DataContext = NewProduct;

        }

        Product selectedProduct = new Product();

        // Event handler to prepare for editing a product
        private void UpdateProductForEdit(object s, RoutedEventArgs e)
        {
            selectedProduct = (s as FrameworkElement).DataContext as Product;
            UpdateProductGrid.DataContext = selectedProduct;
        }

        // Event handler to update a product
        private void UpdateProduct(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedProduct);
            dbContext.SaveChanges();
            GetProducts();
        }
        // Event handler to delete a product
        private void DeleteProduct(object s, RoutedEventArgs e)
        {
            var productToBeDeleted = (s as FrameworkElement).DataContext as Product;
            dbContext.Products.Remove(productToBeDeleted);
            dbContext.SaveChanges();
            GetProducts();
        }
    }
}
