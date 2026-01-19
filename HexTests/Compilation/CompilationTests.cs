
namespace HexTests.Compilation
{
	public class CompilationTests : CompileTestUtilities
	{
		[Test]
		public void Add_a_b()
		{
			var prog = CompileFrom(Constants.kRitual_Add);

			Assert.That(prog, Is.Not.Null);
			Assert.That(prog.Count, Is.EqualTo(13));
		}

		[Test]
		public void Add_a_b__Call()
		{
			var prog = CompileFrom(Constants.Programs.kSimpleAdd);

			Assert.That(prog, Is.Not.Null);
			Assert.That(prog.Count, Is.EqualTo(30));
		}

		[Test]
 		public void FibonacciCompilation()
		{
			//Assert.Ignore();
			var prog = CompileFrom(Constants.Programs.kFibonacci);

			Assert.That(prog, Is.Not.Null);
			Assert.That(prog.Count, Is.EqualTo(46));
		}
	}
}
