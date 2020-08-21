using System;
using System.Xml.Serialization;

// Для XML сериализации используются атрибуты [Xml...]
// [XmlElement]
// [XmlAttribute]
// [XmlIgnore] 
// [XmlText]
// [XmlRoot]
// [XmlNamespaceDeclarations]
// [XmlEnum]
// и др.

namespace Serialization
{
    public class Vector3D
    {
        // Конструктор без параметров - обязательное требование для XML сериализации
        public Vector3D() { }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        [XmlAttribute] // Атрибут показывает, что это свойство должно сериализоваться как XML атрибут
        public double X { get; set; }

        [XmlAttribute]
        public double Y { get; set; }

        [XmlAttribute]
        public double Z { get; set; }

        [XmlIgnore] // Атрибут показывает, что это свойство не должно сериализоваться в XML
        public double Length { get { return Math.Sqrt(X * X + Y * Y + Z * Z); } }

        public override string ToString()
        {
            return $"({X}; {Y}; {Z})";
        }
    }
}
