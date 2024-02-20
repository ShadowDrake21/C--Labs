using System.Collections.Generic;
using System;
using System.Xml.Serialization;

namespace ua.cn.stu
{
    class Program
    {
        private static LinkedList<Product> productLinkedList = new LinkedList<Product>();
        static void Main(string[] args)
        {
            Console.Title = "Krapyvianskiy D. PI-211";
            for (; ; )
            {
                Console.WriteLine("-- Please enter command addFirst, removeFirst, addLast, removeLast, remove, addAfter, show or exit --");
                string command = Console.ReadLine();

                if (command == "exit")
                {
                    Console.WriteLine("Exiting the program.");
                    return;
                }
                else
                {
                    CommandProcessing(command);
                }
            }
        }

        public static void CommandProcessing(string command)
        {
            if (command == "addFirst")
            {
                Product product = createProduct();
                productLinkedList.AddFirst(product);
                Console.WriteLine();
            }
            else if (command == "removeFirst")
            {
                productLinkedList.RemoveFirst();
                Console.WriteLine();
            }
            else if (command == "addLast")
            {
                Product product = createProduct();
                productLinkedList.AddLast(product);
                Console.WriteLine();
            }
            else if (command == "removeLast")
            {
                productLinkedList.RemoveLast();
                Console.WriteLine();
            }
            else if (command == "remove")
            {
                Console.WriteLine("Please enter product name:");
                string name = Console.ReadLine();

                Product deleteProduct = productLinkedList.FirstOrDefault(product => product.name == name);

                if (deleteProduct != null)
                {
                    Console.WriteLine("Removing product: " + deleteProduct.name + ", area: " + deleteProduct.useArea);
                    productLinkedList.Remove(deleteProduct);
                }
                else
                {
                    Console.WriteLine("Product not found");
                }
                Console.WriteLine();
            }
            else if (command == "addAfter")
            {
                Console.WriteLine("Please enter product name after what you want to add a new product:");
                string afterName = Console.ReadLine();

                Product afterProduct = productLinkedList.FirstOrDefault(product => product.name == afterName);

                if (afterProduct != null)
                {

                    Product product = createProduct();

                    LinkedListNode<Product> node = productLinkedList.Find(afterProduct);

                    if (node != null)
                    {
                        productLinkedList.AddAfter(node, product);
                        Console.WriteLine("Product added after " + afterProduct.name);
                    }
                    else
                    {
                        Console.WriteLine("Product not found");
                    }
                }
                else
                {
                    Console.WriteLine("Product not found");
                }
                Console.WriteLine();
            }
            else if (command == "show")
            {
                foreach (Product product in productLinkedList)
                {
                    Console.WriteLine("name: " + product.name + ", area: " + product.useArea + ", need of wifi: " + product.needWiFi + ", class: " + product.classType + ", price: " + product.price);
                }
                Console.WriteLine();
            }
            else if (command == "saveXML")
            {
                SaveXML();
                Console.WriteLine();
            }
        }

        public static Product createProduct()
        {
            Console.WriteLine("Please enter product name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter product use area:");
            string useArea = Console.ReadLine();
            Console.WriteLine("Please enter whether a product needs wifi (true/false):");
            bool needWiFi = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Please enter product class (A - high, B - upper-middle, C - middle, D - low):");
            string classType = Console.ReadLine();
            // char classType = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Please enter product price:");
            float price = float.Parse(Console.ReadLine());
            Product product = new Product(name, useArea, needWiFi, classType, price);
            return product;
        }

        public static void SaveXML()
        {
            try
            {
                Console.WriteLine("Please enter the filename to save:");
                string filename = Console.ReadLine();

                // xmlserializer do not like linkedList, so I didnt have another way xd
                List<Product> productList = new List<Product>(productLinkedList);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
                Stream stream = new FileStream(filename + ".xml", FileMode.Create, FileAccess.Write, FileShare.None);
                serializer.Serialize(stream, productList);
                stream.Close();
                Console.WriteLine("Serialization successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during serialization: " + ex.Message);
            }
        }
    }
}

