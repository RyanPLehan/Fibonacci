using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fibonacci;

namespace FibonacciTest
{
    [TestClass]
    public class FibonacciTest
    {
        Fibonacci.Fibonacci _fibSeqGen = null;

        [TestInitialize]
        public void Initialize()
        {
            _fibSeqGen = new Fibonacci.Fibonacci();
        }


        [TestMethod]
        public void TestGenerateSequence()
        {
            decimal cnt = 1;

            IEnumerable<decimal> seq = _fibSeqGen.GenerateSequence();
            foreach (decimal d in seq)
                Console.WriteLine("{0}: {1}", cnt++, d);
        }


        [TestMethod]
        public void TestGenerateSequence_10()
        {
            decimal cnt = 1;
            uint maxSeq = 10;

            Console.WriteLine("Testing with a maximum limit of {0}", maxSeq);

            IEnumerable<decimal> seq = _fibSeqGen.GenerateSequence(maxSeq);
            Console.WriteLine("Sequence Count {0}", seq.Count());

            foreach (decimal d in seq)
                Console.WriteLine("{0}: {1}", cnt++, d);

            Assert.AreEqual(Convert.ToInt32(maxSeq), seq.Count());
        }


        [TestMethod]
        public void TestGenerateSequence_200()
        {
            decimal cnt = 1;
            uint maxSeq = 200;

            Console.WriteLine("Testing with a maximum limit of {0}", maxSeq);

            IEnumerable<decimal> seq = _fibSeqGen.GenerateSequence(maxSeq);
            Console.WriteLine("Sequence Count {0}", seq.Count());

            foreach (decimal d in seq)
                Console.WriteLine("{0}: {1}", cnt++, d);

            Assert.AreNotEqual(Convert.ToInt32(maxSeq), seq.Count());
        }


        [TestMethod]
        public void TestContains_False()
        {
            decimal d = 10;
            Assert.IsFalse(_fibSeqGen.Contains(d));
        }


        [TestMethod]
        public void TestContains_True()
        {
            decimal d = 50095301248058391139327916261M;
            Assert.IsTrue(_fibSeqGen.Contains(d));
        }

        [TestMethod]
        public void TestConvertToList()
        {
            IList<decimal> list = null;

            IEnumerable<decimal> seq = _fibSeqGen.GenerateSequence();
            list = seq.ToList();

            Assert.AreEqual(seq.Count(), list.Count());
        }
    }
}
