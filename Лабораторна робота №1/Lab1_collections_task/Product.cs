using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ua.cn.stu
{
    [Serializable]
    public class Product
    {
        // private string name;
        // private string useArea;
        // private bool needWiFi;
        // private char classType; // A - high, B - upper-middle, C - middle, D - low
        // private float price;

        // public Product(string name, string useArea, bool needWiFi, char classType, float price)
        // {
        //     this.name = name;
        //     this.useArea = useArea;
        //     this.needWiFi = needWiFi;
        //     this.classType = classType;
        //     this.price = price;
        // }

        // public Product() { }

        // public string getName()
        // {
        //     return this.name;
        // }
        // public string getUseArea()
        // {
        //     return this.useArea;
        // }
        // public bool getNeedWiFi()
        // {
        //     return this.needWiFi;
        // }
        // public char getClassType()
        // {
        //     return this.classType;
        // }
        // public float getPrice()
        // {
        //     return this.price;
        // }


        // public void setName(string name)
        // {
        //     this.name = name;
        // }
        // public void setUseArea(string useArea)
        // {
        //     this.useArea = useArea;
        // }
        // public void setNeedWiFi(bool needWiFi)
        // {
        //     this.needWiFi = needWiFi;
        // }
        // public void setClassType(char classType)
        // {
        //     this.classType = classType;
        // }
        // public void setPrice(float price)
        // {
        //     this.price = price;
        // }

        public string name { get; set; }
        public string useArea { get; set; }
        public bool needWiFi { get; set; }
        public string classType { get; set; } // A - high, B - upper-middle, C - middle, D - low 
        // was a char, but XML serialization dont support char, so now it is a string
        public float price { get; set; }

        public Product(string name, string useArea, bool needWiFi, string classType, float price)
        {
            this.name = name;
            this.useArea = useArea;
            this.needWiFi = needWiFi;
            this.classType = classType;
            this.price = price;
        }

        public Product() { }
    }
}