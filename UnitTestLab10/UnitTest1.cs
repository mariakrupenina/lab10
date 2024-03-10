using lab_10_;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using library_for_lab10;
using static library_for_lab10.Tool;

namespace UnitTestLab10
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ToolWithoutParam()//констурктор без параметра
        {
            //Arrange
            Tool tool1 = new Tool("Без названия", 1); //ожидаемо
            //Act
            Tool tool2 = new Tool(); //собираемся проверять
            //Assert
            Assert.AreEqual(tool2.Name, tool1.Name); //сравнение
            Assert.AreEqual(tool2.id, tool1.id);
        }

        [TestMethod]
        public void ToolWithParam()//конструктор с параметром
        {
            //Arrange
            Tool tool1 = new Tool("Без названия", 1); //ожидаемо
            //Act
            string name = "Без названия";
            int id = 1;
            Tool tool = new Tool(name, id); //собираемся проверять
            //Assert
            Assert.AreEqual(tool.Name, tool1.Name); //сравнение
            Assert.AreEqual(tool.id, tool1.id);
        }

        [TestMethod]
        public void TestNameSetter()
        {
            //Arrange
            Tool tool = new Tool(); //ожидаемо
            //Act
            tool.Name = "дрель"; //собираемся проверять
            //Assert
            Assert.AreEqual("дрель", tool.Name);//сравнение
        }

        [TestMethod]
        public void TestNameGetter()
        {
            //Arrange
            Tool tool = new Tool();
            tool.Name = "дрель"; //ожидаемо
            //Act
            string result = tool.Name; //собираемся проверять
            //Assert
            Assert.AreEqual("дрель", result); //сравнение
        }

        [TestMethod]
        public void TestEquals()
        {
            //Arrange
            Tool tool1 = new Tool("дрель", 1); //ожидаемо
            Tool tool2 = new Tool("дрель", 1);
            //Act
            bool result = tool1.Equals(tool2);//собираемся проверять
            //Assert
            Assert.IsTrue(result);//сравнение
        }


        [TestMethod]
        public void TestToString()
        {
            //Arrange
            IdNumber id = new IdNumber(7);//ожидаемо
            //Act
            string result = id.ToString(); //собираемся проверять
            //Assert
            Assert.AreEqual(result, "7"); //сравнение
        }

        [TestMethod]
        public void MiscellaneousTest()
        {
            //Arrange
            IdNumber tool1 = new IdNumber(8);//ожидаемо
            IdNumber tool2 = new IdNumber(9);
            //Act
            int result = tool1.Compare(tool1, tool2);//собираемся проверять
            //Assert
            Assert.AreEqual(-1, result); //сравнение
        }

        [TestMethod]
        public void SameObjectsTest()
        {
            //Arrange
            Tool tool = new Tool(); //ожидаемо
            tool.Name = "Original";
            //Act
            Tool clonedTool = (Tool)tool.Clone(); //собираемся проверять
            //Assert
            Assert.AreEqual(tool.Id, clonedTool.Id);  //сравнение
            Assert.AreEqual(tool.Name, clonedTool.Name);  //сравнение
        }

        [TestMethod]
        public void HandToolWithoutParams()
        {
            //Arrange
            HandTool handtool = new HandTool();//ожидаемо
            //Act
            string material = handtool.GetMaterial();//собираемся проверять
            // Assert
            Assert.AreEqual("материал не определён", material);//сравнение
        }

        [TestMethod]
        public void HandToolWithParam()
        {
            //Arrange
            int id = 1; //ожидаемо
            string name = "молоток";
            string material = "дерево+";
            //Act
            HandTool handTool = new HandTool(name, material, id);//собираемся проверять
            // Assert
            //Assert.AreEqual(id, handTool.Id);//сравнение
            Assert.AreEqual(name, handTool.Name);
            Assert.AreEqual(material, handTool.Material);
        }

        [TestMethod]
        public void HandToolEquals()
        {
            //Arange
            HandTool tool1 = new HandTool("пассатижи", "нет", 10);//ожидаемо
            HandTool tool2 = new HandTool("пассатижи", "нет", 10);
            // Act
            bool result = tool1.Equals(tool2); //собираемся проверять
            // Assert
            Assert.IsTrue(result); //сравнение
        }

        [TestMethod]
        public void ElectricToolWithParam()
        {
            //Arrange
            int id = 1; //ожидаемо
            string name = "молоток";
            string material = "дерево+";
            string source = "аккумулятор";
            double time = 0;
            //Act
            ElectricTool electricTool = new ElectricTool(name, material, source, time, id);//собираемся проверять
            // Assert
            //Assert.AreEqual(id, handTool.Id);//сравнение
            Assert.AreEqual(name, electricTool.Name);
            Assert.AreEqual(material, electricTool.Material);
            Assert.AreEqual(source, electricTool.PowerSource);
            Assert.AreEqual(time, electricTool.BatteryTime);
        }

        [TestMethod]
        public void ElectricToolWithParam2()
        {
            // Arramge
            ElectricTool tool = new ElectricTool();
            //Act
            tool.BatteryTime = 100;
            // Assert
            Assert.AreEqual(0, tool.BatteryTime);
        }

        [TestMethod]
        public void ElectricToolEqualsWithoutParams()
        {
            //Arrange
            ElectricTool tool1 = new ElectricTool();
            //Act
            ElectricTool tool2 = new ElectricTool("Без названия", "материал не определён", "без источника", 0, 1);
            //Assert
            Assert.IsTrue(tool1.Equals(tool2));
        }

        [TestMethod]
        public void ElectricToolNotEquals()
        {
            //Arrange
            ElectricTool tool1 = new ElectricTool();
            //Act
            ElectricTool tool2 = new ElectricTool("Без названия1", "материал не определён1", "без источника1", 0, 1);
            //Aseert
            Assert.IsFalse(tool1.Equals(tool2));
        }

        [TestMethod]
        public void MeasuringToolIscl()
        {
            //Arrange
            MeasuringTool tool = new MeasuringTool();
            //Act
            tool.Accuracy = -100;
            //Assert
            Assert.AreEqual(0, tool.Accuracy);
        }

        [TestMethod]
        public void MeasuringTool()
        {
            //Arrange
            MeasuringTool tool = new MeasuringTool();
            //Act
            tool.Accuracy = -100;
            //Assert
            Assert.AreEqual(0, tool.Accuracy);
        }

        [TestMethod]
        public void MeasuringToolEqualsWithoutParams()
        {
            //Arrange
            MeasuringTool tool1 = new MeasuringTool();
            //Act
            MeasuringTool tool2 = new MeasuringTool("Без названия", "материал не определён", "без единиц измерения" , 0, 1);
            //Assert
            Assert.IsTrue(tool1.Equals(tool2));
        }

        [TestMethod]
        public void MeasuringToolNotEquals()
        {
            //Arrange
            MeasuringTool tool1 = new MeasuringTool();
            //Act
            MeasuringTool tool2 = new MeasuringTool("Без названия1", "материал не определён1", "без", 0, 1);
            //Aseert
            Assert.IsFalse(tool1.Equals(tool2));
        }

        [TestMethod]
        public void MeasuringToolWithoutParams()
        {
            //Arrange
            MeasuringTool tool = new MeasuringTool();//ожидаемо
            //Act
            double accuracy = tool.GetAccuracy();//собираемся проверять
            // Assert
            Assert.AreEqual(0, accuracy);//сравнение
        }


    }
}