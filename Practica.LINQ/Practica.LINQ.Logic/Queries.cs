using Practica.LINQ.Data;
using Practica.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.LINQ.Logic
{
    public class Queries
    {
        private readonly NorthwindContext _context;

        public Queries()
        {
            _context = new NorthwindContext();
        }

        // 1 - Query para devolver objeto customer
        // No entiendo si piden cualquiera o retornar un objeto Customer constante
        // Lo tome como devolver cualquier objeto customer, asi que agarre el primero
        public Customers Query1()
        {
            return _context.Customers.First();
        }

        // 2 - Query para devolver todos los productos sin stock
        public IQueryable<Products> Query2()
        {
            var products = _context.Products;
            var productsWithNoStock = from p in products
                                      where p.UnitsInStock == 0
                                      select p;
            
            return productsWithNoStock;
        }

        // 3 - Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad
        public IQueryable<Products> Query3()
        {
            return _context.Products.Where(p => p.UnitsInStock >= 1 && p.UnitPrice > 3);
        }

        // 4 - Query para devolver todos los customers de la Región WA
        public IQueryable<Customers> Query4()
        {
            var customers = _context.Customers;
            var customersInWA = from c in customers
                                where c.Region == "WA"
                                select c;
            
            return customersInWA;
        }

        // 5 - Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789
        public Products Query5()
        {
            return _context.Products.FirstOrDefault( p => p.ProductID == 789);
        }

        // 6 - Query para devolver los nombre de los Customers y despues mostrarlos en minusculas y mayusculas
        public IQueryable<string> Query6()
        {
            var customers = _context.Customers;
            var customersNames = from c in customers
                                 select c.ContactName;

            return customersNames;
        }

        // 7 - Query para devolver Join entre Customers y Orders donde los customers sean
        // de la Región WA y la fecha de orden sea mayor a 1/1/1997
        public IQueryable<CustomerOrderJoined> Query7()
        {
            var orders = _context.Orders;
            var customers = _context.Customers;

            var customersJoinedOrders = from c in customers
                                        join o in orders on c.CustomerID equals o.CustomerID
                                        where c.Region == "WA"
                                        where o.OrderDate >= new DateTime(1997, 1, 1)
                                        select new CustomerOrderJoined() { CustomerID = c.CustomerID, 
                                            OrderDate = o.OrderDate, Region = c.Region };

            return customersJoinedOrders;
        }

        // 8 - Query para devolver los primeros 3 Customers de la  Región WA
        public IQueryable<Customers> Query8()
        {
            return _context.Customers.Where(c => c.Region == "WA").Take(3);
        }

        // 9 - Query para devolver lista de productos ordenados por nombre
        public List<Products> Query9()
        {
            return _context.Products.OrderBy(p => p.ProductName).ToList();
        }

        // 10 - Query para devolver lista de productos ordenados por unit in stock de mayor a menor
        public List<Products> Query10()
        {
            var products = _context.Products;
            var productsOrderedByStock = (from p in products
                                         orderby p.UnitsInStock descending
                                         select p).ToList();
            
            return productsOrderedByStock;
        }

        // 11 - Query para devolver las distintas categorías asociadas a los productos
        public IQueryable<string> Query11()
        {
            var products = _context.Products;
            var categories = _context.Categories;

            var productsJoinedCategories = (from p in products
                                           join c in categories on p.CategoryID equals c.CategoryID
                                           select c.CategoryName).Distinct();
            return productsJoinedCategories;
        }

        // 12 - Query para devolver el primer elemento de una lista de productos
        public Products Query12(List<Products> listOfProducts)
        {
            return listOfProducts.FirstOrDefault();
        }
        // 13 -  Query para devolver los customer con la cantidad de ordenes asociadas
        public IQueryable<CustomerOrderGroupJoined> Query13()
        {
            var customers = _context.Customers;
            var orders = _context.Orders;

            var customersJoinedOrders = from c in customers
                                        join o in orders on c.CustomerID equals o.CustomerID
                                        group new { c, o.OrderID } by c.CustomerID into grouped
                                        select new CustomerOrderGroupJoined() { CustomerID = grouped.Key, Count = grouped.Count(t => t.OrderID != null) };

            return customersJoinedOrders;
        }
    }
}