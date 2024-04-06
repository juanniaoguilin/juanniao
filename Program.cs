using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    //定义一个接口 IProductionFactory，它包含了生产鸭脖和鸭翅的方法。
    //这样，我们可以为不同的工厂实现统一的接口，便于管理和使用。
    public interface IProductionFactory
    {
        void ProduceDuckNeck();
        void ProduceDuckWing();
    }
    //分别实现三个工厂类：WuhanFactory、NanjingFactory 和 ChangshaFactory
    //它们各自实现了 IProductionFactory 接口。
    public class WuhanFactory : IProductionFactory
    {
        public void ProduceDuckNeck()
        {
            Console.WriteLine("武汉工厂生产鸭脖");
        }

        public void ProduceDuckWing()
        {
            Console.WriteLine("武汉工厂生产鸭翅");
        }
    }

    public class NanjingFactory : IProductionFactory
    {
        public void ProduceDuckNeck()
        {
            throw new NotImplementedException("南京工厂不能生产鸭脖");//对于不能生产的产品，我们抛出了 NotImplementedException 异常
                                                                    //用于表明该类不支持该方法。
        }

        public void ProduceDuckWing()
        {
            Console.WriteLine("南京工厂生产鸭翅");
        }
    }

    public class ChangshaFactory : IProductionFactory
    {
        public void ProduceDuckNeck()
        {
            Console.WriteLine("长沙工厂生产鸭脖");
        }

        public void ProduceDuckWing()
        {
            throw new NotImplementedException("长沙工厂不能生产鸭翅");
        }
    }
    //使用委托 ProductionDelegate 定义生产委托。
    //委托类似于 C 语言中的函数指针，可以引用一个具有特定签名的方法。
    public delegate void ProductionDelegate();
    class Program
    {
        //在 Main 函数中，我们创建不同工厂的实例，并通过生产委托进行生产。
        static void Main(string[] args)
        {
            // 创建工厂实例  
            IProductionFactory wuhanFactory = new WuhanFactory();
            IProductionFactory nanjingFactory = new NanjingFactory();
            IProductionFactory changshaFactory = new ChangshaFactory();

            // 定义生产委托  
            ProductionDelegate produceDelegate;

            // 武汉工厂可以生产鸭脖和鸭翅  
            produceDelegate = wuhanFactory.ProduceDuckNeck;
            produceDelegate(); // 调用委托执行方法  
            produceDelegate = wuhanFactory.ProduceDuckWing;
            produceDelegate();

            // 南京工厂只能生产鸭翅  
            produceDelegate = nanjingFactory.ProduceDuckWing;
            produceDelegate();

            // 尝试让南京工厂生产鸭脖，这里会抛出异常  
            //produceDelegate = nanjingFactory.ProduceDuckNeck;  
            //produceDelegate();  

            // 长沙工厂只能生产鸭脖  
            produceDelegate = changshaFactory.ProduceDuckNeck;
            produceDelegate();

            // 尝试让长沙工厂生产鸭翅，这里会抛出异常  
             produceDelegate = changshaFactory.ProduceDuckWing;  
             produceDelegate();  

            Console.ReadKey();
        }
    }
}
