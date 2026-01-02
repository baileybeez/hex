
using Hex.Arcanum.Common;
using System.Text;

namespace HexTests.IR
{
	public class SaveLoad
	{
		[Test]
		public void Save_And_Load_IR()
		{
			IRInst inst = new IRInst(OpCode.Call, "t0", "func_TEST", null);

			using var ms = new MemoryStream();
			using var bw = new BinaryWriter(ms);

			IRFile.WriteIR(bw, inst);

			byte[] data = ms.ToArray();
			Assert.That(data, Is.Not.Null);
			Assert.That(data.Length, Is.GreaterThan(0));

			ms.Seek(0, SeekOrigin.Begin);
			using var br = new BinaryReader(ms);

			IRInst loaded = IRFile.ReadIR(br);

			Assert.That(loaded.opCode, Is.EqualTo(inst.opCode));
			Assert.That(loaded.result, Is.EqualTo(inst.result));
			Assert.That(loaded.leftOperand, Is.EqualTo(inst.leftOperand));
			Assert.That(loaded.rightOperand, Is.EqualTo(inst.rightOperand));
		}
	}
}
